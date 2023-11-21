using Domain.Models;
using MediatR;


namespace Application.Querys.Dogs.CreateDog
{
    public class CreateDogQuery : IRequest<Dog>
    {
        public string Name { get; set; }

    }
}
