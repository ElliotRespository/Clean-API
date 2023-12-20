using Application.Dtos.Animal;
using Domain.Models.Animalmodels;
using MediatR;

namespace Application.Commands.Cats.CreateCat
{
    public class CreateCatCommand : IRequest<Cat>
    {
        public CreateCatCommand(AnimalDto newCat)
        {
            NewCat = newCat;

        }

        public AnimalDto NewCat { get; }
    }
}
