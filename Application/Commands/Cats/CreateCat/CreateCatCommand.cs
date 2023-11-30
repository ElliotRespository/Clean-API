using Application.Dtos;
using Domain.Models.Animalmodels;
using MediatR;

namespace Application.Commands.Cats.CreateCat
{
    public class CreateCatCommand : IRequest<Cat>
    {
        public required AnimalDto Cat { get; set; }
    }
}
