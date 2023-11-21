using Domain.Models;
using MediatR;


namespace Application.Commands.Dogs.CreateDog
{
    public class CreateDogCommand : IRequest<Dog>
    {
        public string Name { get; set; }
    }
}
