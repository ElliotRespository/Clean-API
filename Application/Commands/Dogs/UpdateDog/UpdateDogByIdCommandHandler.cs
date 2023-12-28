using Application.Services.Animals.Dogs_Cats;
using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly IDogService _dogService;
        private readonly ILogger<UpdateDogByIdCommandHandler> _logger;

        public UpdateDogByIdCommandHandler(IDogService dogService, ILogger<UpdateDogByIdCommandHandler> logger)
        {
            _dogService = dogService;
            _logger = logger;
        }

        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _dogService.UpdateDogAsync(request.Id, request.UpdatedDog);
                var updatedDog = await _dogService.GetDogByIdAsync(request.Id);
                _logger.LogInformation("Dog updated successfully: {DogId}", updatedDog.AnimalID);
                return updatedDog;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Dog not found for update: {DogId}", request.Id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating dog: {DogId}", request.Id);
                throw;
            }
        }
    }
}
