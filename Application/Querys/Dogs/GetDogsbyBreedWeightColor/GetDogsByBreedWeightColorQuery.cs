#nullable disable
using Domain.Models.Animalmodels;
using MediatR;


namespace Application.Querys.Dogs.GetDogsbyBreedWeightColor
{
    public class GetDogsByBreedWeightColorQuery : IRequest<IEnumerable<Dog>>
    {
        public string Breed { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }
    }
}
