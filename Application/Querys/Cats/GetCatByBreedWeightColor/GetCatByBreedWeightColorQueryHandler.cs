using Application.Services.Animals.Dogs_Cats;
using Domain.Models.Animalmodels;
using MediatR;

namespace Application.Querys.Cats.GetCatByBreedWeightColor
{
    public class GetCatsByBreedWeightColorQueryHandler : IRequestHandler<GetCatsByBreedWeightColorQuery, IEnumerable<Cat>>
    {
        private readonly ICatService _catService;

        public GetCatsByBreedWeightColorQueryHandler(ICatService catService)
        {
            _catService = catService;
        }

        public async Task<IEnumerable<Cat>> Handle(GetCatsByBreedWeightColorQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(request.Breed) && !request.Weight.HasValue && string.IsNullOrWhiteSpace(request.Color))
            {
                return await _catService.GetCatsByBreedAsync(request.Breed);
            }


            return await _catService.GetCatsByBreedWeightAndColorAsync(request.Breed, request.Weight, request.Color);
        }
    }
}