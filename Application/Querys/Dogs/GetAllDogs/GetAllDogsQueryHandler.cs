using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Querys.Dogs.GetAllDogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ILogger<GetAllDogsQueryHandler> _logger;

        public GetAllDogsQueryHandler(IAnimalRepository animalRepository, ILogger<GetAllDogsQueryHandler> logger)
        {
            _animalRepository = animalRepository;
            _logger = logger;
        }
        public async Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _animalRepository.GetAllDogsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all dogs");
                throw;
            }
        }
    }
}
