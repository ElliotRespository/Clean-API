using Application.Dtos.Dogdto;
using Domain.Models.Animalmodels;
using MediatR;


namespace Application.Commands.Dogs.UpdateDog
{
    public  class UpdateDogByIdCommand : IRequest<Dog>
    {
        public UpdateDogByIdCommand(DogDto updateDog, Guid id)
        {
            UpdatedDog = updateDog;
            this.Id = id;
        }

        public DogDto UpdatedDog { get; }
        public Guid Id { get; }

    }
}
