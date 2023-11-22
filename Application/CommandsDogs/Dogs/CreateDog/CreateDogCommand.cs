using Application.Dtos.Dogdto;
using Domain.Models;
using MediatR;


namespace Application.Commands.Dogs.CreateDog
{
    public class CreateDogCommand : IRequest<Dog>
    {
        public DogDto Dog { get; set; }
    }
}
