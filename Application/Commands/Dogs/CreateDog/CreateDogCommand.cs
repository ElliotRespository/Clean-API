using Application.Dtos;
using Domain.Models.Animalmodels;
using MediatR;


namespace Application.Commands.Dogs.CreateDog
{
    public class CreateDogCommand : IRequest<Dog>
    {
        public CreateDogCommand(AnimalDto newDog)
        {
            NewDog = newDog;

        }

        public AnimalDto NewDog { get; }
    }
}
