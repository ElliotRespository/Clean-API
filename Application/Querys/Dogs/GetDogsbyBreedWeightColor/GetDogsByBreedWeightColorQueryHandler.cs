using Application.Services.Animals.Dogs_Cats;
using Domain.Models.Animalmodels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Querys.Dogs.GetDogsbyBreedWeightColor
{
    public class GetDogsByBreedWeightColorQueryHandler : IRequestHandler<GetDogsByBreedWeightColorQuery, IEnumerable<Dog>>
    {
        private readonly IDogService _dogService;

        public GetDogsByBreedWeightColorQueryHandler(IDogService dogService)
        {
            _dogService = dogService;
        }

        public async Task<IEnumerable<Dog>> Handle(GetDogsByBreedWeightColorQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(request.Breed) && !request.Weight.HasValue && string.IsNullOrWhiteSpace(request.Color))
            {
                return await _dogService.GetDogsByBreedAsync(request.Breed);
            }

            return await _dogService.GetDogsByBreedWeightAndColorAsync(request.Breed, request.Weight, request.Color);

        }
    }
}
