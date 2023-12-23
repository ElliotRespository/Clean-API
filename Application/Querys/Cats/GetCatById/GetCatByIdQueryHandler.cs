using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Querys.Cats.GetCatById
{
    public class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, Cat>
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ILogger<GetCatByIdQueryHandler> _logger;

        public GetCatByIdQueryHandler(IAnimalRepository animalRepository, ILogger<GetCatByIdQueryHandler> logger)
        {
            _animalRepository = animalRepository;
            _logger = logger;
        }

        public async Task<Cat> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cat = await _animalRepository.GetCatByIdAsync(request.Id);
                if (cat == null)
                {
                    _logger.LogWarning("Cat not found: {CatId}", request.Id);
                    throw new KeyNotFoundException($"Cat with ID {request.Id} was not found.");
                }
                return cat;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving cat: {CatId}", request.Id);
                throw;
            }
        }
    }
}
