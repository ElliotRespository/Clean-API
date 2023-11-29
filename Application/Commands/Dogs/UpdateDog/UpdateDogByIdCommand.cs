using Application.Dtos;
using Domain.Models.Animalmodels;
using MediatR;


namespace Application.Commands.Dogs.UpdateDog
{
    public  class UpdateDogByIdCommand : IRequest<Dog>
    {
        public UpdateDogByIdCommand(AnimalDto updateDog, Guid id)
        {
            UpdatedDog = updateDog;
            this.Id = id;
        }

        public AnimalDto UpdatedDog { get; }
        public Guid Id { get; }

    }
}
