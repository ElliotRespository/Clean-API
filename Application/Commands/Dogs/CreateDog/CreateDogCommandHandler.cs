using Domain.Models;
using Infrastructure.Database;
using MediatR;


namespace Application.Commands.Dogs.CreateDog
{
    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public Task<Dog> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            var newDog = new Dog { Name = request.Name, animalID = Guid.NewGuid() };
            _mockDatabase.allDogs.Add(newDog);
            return Task.FromResult(newDog);
        }
    }
}
