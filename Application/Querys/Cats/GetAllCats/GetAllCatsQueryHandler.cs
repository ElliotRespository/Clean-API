using Application.Services.Animals.Dogs_Cats;
using Domain.Models.Animalmodels;
using Infrastructure.Database.SqlDataBases;
using Infrastructure.Repository.Animals;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Application.Querys.Cats.GetAllCats
{
    public class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly ICatService _catService;
        private readonly ILogger<GetAllCatsQueryHandler> _logger;

        public GetAllCatsQueryHandler(ICatService catService, ILogger<GetAllCatsQueryHandler> logger)
        {
            _catService = catService;
            _logger = logger;
        }

        public async Task<List<Cat>> Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var cats = await _catService.GetAllCatsAsync();
                return cats.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving all cats");
                throw;
            }
        }
    }
}
