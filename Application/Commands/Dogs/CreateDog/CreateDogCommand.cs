using Application.Dtos;
using Domain.Models.Animalmodels;
using MediatR;


namespace Application.Commands.Dogs.CreateDog
{
    public class CreateDogCommand : IRequest<Dog>
    {
        public AnimalDto Dog { get; set; }
    }
}
