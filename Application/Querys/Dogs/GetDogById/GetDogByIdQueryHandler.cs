using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Querys.Dogs.GetDogById
{

    public class GetDogByIdQueryHandler : IRequestHandler<GetDogByIdQuery, Dog>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ILogger<GetDogByIdQueryHandler> _logger;

        public GetDogByIdQueryHandler(IAnimalRepository animalRepository, ILogger<GetDogByIdQueryHandler> logger)
        {
            _animalRepository = animalRepository;
            _logger = logger;
        }

        public async Task<Dog> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dog = await _animalRepository.GetDogByIdAsync(request.Id);
                if (dog == null)
                {
                    _logger.LogWarning("Dog not found: {DogId}", request.Id);
                    throw new KeyNotFoundException($"Dog with ID {request.Id} was not found.");
                }
                return dog;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving dog: {DogId}", request.Id);
                throw;
            }
        }
    }
}
