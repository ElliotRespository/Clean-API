using Application.Services.Animals.Dogs_Cats;
using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly IDogService _dogService;
        private readonly ILogger<DeleteDogByIdCommandHandler> _logger;

        public DeleteDogByIdCommandHandler(IDogService dogService, ILogger<DeleteDogByIdCommandHandler> logger)
        {
            _dogService = dogService;
            _logger = logger;
        }

        public async Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dog = await _dogService.GetDogByIdAsync(request.Id);
                if (dog == null)
                {
                    _logger.LogWarning("Dog not found for deletion: {DogId}", request.Id);
                    throw new KeyNotFoundException($"Dog with ID {request.Id} was not found.");
                }

                await _dogService.DeleteDogAsync(request.Id);
                _logger.LogInformation("Dog deleted: {DogId}", request.Id);
                return dog;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting dog: {DogId}", request.Id);
                throw;
            }
        }
    }
}


