using Application.Dtos.Animal;
using Domain.Models.Animalmodels;
using MediatR;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommand : IRequest<Cat>
    {
        public UpdateCatByIdCommand(AnimalDto updateCat, Guid id)
        {
            UpdatedCat = updateCat;
            this.Id = id;
        }

        public AnimalDto UpdatedCat { get; }
        public Guid Id { get; }
    }
}
