#nullable disable
using Domain.Models.Animalmodels;
using MediatR;


namespace Application.Querys.Cats.GetCatByBreedWeightColor
{
    public class GetCatsByBreedWeightColorQuery : IRequest<IEnumerable<Cat>>
    {
        public string Breed { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }
    }
}
