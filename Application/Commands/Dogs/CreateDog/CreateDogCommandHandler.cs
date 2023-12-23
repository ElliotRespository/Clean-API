using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Commands.Dogs.CreateDog
{
    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, Dog>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ILogger<CreateDogCommandHandler> _logger;

        public CreateDogCommandHandler(IAnimalRepository animalRepository, ILogger<CreateDogCommandHandler> logger)
        {
            _animalRepository = animalRepository;
            _logger = logger;
        }

        public async Task<Dog> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newDog = new Dog
                {
                    Name = request.NewDog.Name,
                    AnimalID = Guid.NewGuid()
                };

                await _animalRepository.AddAsync(newDog);
                _logger.LogInformation("New dog created: {DogId}", newDog.AnimalID);
                return newDog;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new dog");
                throw;
            }
        }
    }
}
