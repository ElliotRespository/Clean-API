using Domain.Models;
using Infrastructure.Database;
using MediatR;


namespace Application.Querys.Dogs.CreateDog
{
    public class CreateDogQueryHandler : IRequestHandler<CreateDogQuery, Dog>
    {
        private readonly MockDatabase _mockDatabase;
        public CreateDogQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Dog> Handle(CreateDogQuery request, CancellationToken cancellationToken)
        {
            var newDog = new Dog
            {
                Name = request.Name,
                animalID = Guid.NewGuid()
            };
            _mockDatabase.allDogs.Add(newDog);
            return Task.FromResult(newDog);
        }
    }
}
