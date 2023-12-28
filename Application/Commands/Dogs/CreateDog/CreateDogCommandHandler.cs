using Application.Services.Animals.Dogs_Cats;
using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Commands.Dogs.CreateDog
{
    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, Dog>
    {
        private readonly IDogService _dogService;
        private readonly ILogger<CreateDogCommandHandler> _logger;

        public CreateDogCommandHandler(IDogService dogService, ILogger<CreateDogCommandHandler> logger)
        {
            _dogService = dogService;
            _logger = logger;
        }

        public async Task<Dog> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newDog = await _dogService.CreateDogAsync(request.NewDog);
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
