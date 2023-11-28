using Domain.Models.Animalmodels;
using Infrastructure.Database;
using MediatR;


namespace Application.Commands.Dogs.CreateDog
{
    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public CreateDogCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Dog> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            var newDog = new Dog { Name = request.Dog.Name, animalID = Guid.NewGuid() };
            _mockDatabase.allDogs.Add(newDog);
            return Task.FromResult(newDog);
        }
    }
}
