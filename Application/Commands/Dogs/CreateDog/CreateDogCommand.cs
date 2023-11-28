using Application.Dtos.Dogdto;
using Domain.Models.Animalmodels;
using MediatR;


namespace Application.Commands.Dogs.CreateDog
{
    public class CreateDogCommand : IRequest<Dog>
    {
        public DogDto Dog { get; set; }
    }
}
