using Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogCommandHandler : IRequestHandler<DeleteDogCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteDogCommandHandler(MockDatabase mockdatabase)
        {
            _mockDatabase = mockdatabase;
        }

        public Task<Dog> Handle(DeleteDogCommand request, CancellationToken cancellationToken)
        {
            var dogToDelete = _mockDatabase.allDogs.FirstOrDefault(dog => dog.animalID == request.AnimalID);
            if (dogToDelete != null)
            {
                _mockDatabase.allDogs.Remove(dogToDelete);
                return Task.FromResult(dogToDelete);
            }
            else
            {
                return Task.FromResult<Dog>(null!);
            }
        }
    }
}


