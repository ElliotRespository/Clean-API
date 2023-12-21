#nullable disable
using Application.Dtos.UserAnimal;
using Domain.Models;
using MediatR;


namespace Application.Commands.UserAnimal.Update
{
    public class UpdateUserAnimalCommand : IRequest<UserAnimalDto>
    {
        public UpdateUserAnimalDto UpdateUserAnimalDto { get; set; }
    }
}
