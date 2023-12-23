using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Commands.Cats.CreateCat
{
    public class CreateCatCommandHandler : IRequestHandler<CreateCatCommand, Cat>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ILogger<CreateCatCommandHandler> _logger;

        public CreateCatCommandHandler(IAnimalRepository animalRepository, ILogger<CreateCatCommandHandler> logger)
        {
            _animalRepository = animalRepository;
            _logger = logger;
        }

        public async Task<Cat> Handle(CreateCatCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newCat = new Cat
                {
                    Name = request.NewCat.Name,
                    AnimalID = Guid.NewGuid()
                };

                await _animalRepository.AddAsync(newCat);
                _logger.LogInformation("New cat created: {CatId}", newCat.AnimalID);
                return newCat;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new cat");
                throw;
            }

        }
    }
}
