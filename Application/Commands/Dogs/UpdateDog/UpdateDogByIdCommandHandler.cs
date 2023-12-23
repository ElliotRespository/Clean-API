using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ILogger<UpdateDogByIdCommandHandler> _logger;

        public UpdateDogByIdCommandHandler(IAnimalRepository animalRepository, ILogger<UpdateDogByIdCommandHandler> logger)
        {
            _animalRepository = animalRepository;
            _logger = logger;
        }

        public async Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dog = await _animalRepository.GetDogByIdAsync(request.Id);
                if (dog == null)
                {
                    _logger.LogWarning("Dog not found for update: {DogId}", request.Id);
                    throw new KeyNotFoundException($"Dog with ID {request.Id} was not found.");
                }
                dog.Name = request.UpdatedDog.Name;
                await _animalRepository.UpdateAsync(dog);
                _logger.LogInformation("Dog updated successfully: {DogId}", dog.AnimalID);
                return dog;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating dog: {DogId}", request.Id);
                throw;
            }
        }
    }
}
