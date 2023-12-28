using Application.Services.Animals.Dogs_Cats;
using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Querys.Dogs.GetAllDogs
{
    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private readonly IDogService _dogService;
        private readonly ILogger<GetAllDogsQueryHandler> _logger;

        public GetAllDogsQueryHandler(IDogService dogService, ILogger<GetAllDogsQueryHandler> logger)
        {
            _dogService = dogService;
            _logger = logger;
        }
        public async Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dogs = await _dogService.GetAllDogsAsync();
                return dogs.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all dogs");
                throw;
            }
        }
    }
}
