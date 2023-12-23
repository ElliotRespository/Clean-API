using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ILogger<DeleteDogByIdCommandHandler> _logger;

        public DeleteDogByIdCommandHandler(IAnimalRepository animalRepository, ILogger<DeleteDogByIdCommandHandler> logger)
        {
            _animalRepository = animalRepository;
            _logger = logger;
        }

        public async Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dogToDelete = await _animalRepository.GetDogByIdAsync(request.Id);
                if (dogToDelete == null)
                {
                    _logger.LogWarning("Dog not found for deletion: {DogId}", request.Id);
                    throw new KeyNotFoundException($"Dog with ID {request.Id} was not found.");
                }

                await _animalRepository.DeleteAsync<Dog>(request.Id);
                _logger.LogInformation("Dog deleted: {DogId}", request.Id);
                return dogToDelete;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting dog: {DogId}", request.Id);
                throw;
            }
        }
    }
}


