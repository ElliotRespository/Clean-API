#nullable disable
using Application.Dtos.UserAnimal;
using MediatR;


namespace Application.Commands.UserAnimal.Create
{
    public class CreateUserAnimalCommand : IRequest<Guid>
    {
        public UserAnimalDto UserAnimalDto { get; set; }
    }
}
