using Domain.Models.Animalmodels;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogByIdCommandHandler : IRequestHandler<UpdateDogByIdCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public Task<Dog> Handle(UpdateDogByIdCommand request, CancellationToken cancellationToken)
        {
            var dogToUpdate = _mockDatabase.allDogs.FirstOrDefault(dog => dog.animalID == request.Id);
            if (dogToUpdate != null)
            {
                dogToUpdate.Name = request.UpdatedDog.Name;
                return Task.FromResult(dogToUpdate);
            }
            else
            {
                return Task.FromResult<Dog>(null!);
            }
        }
    }
}
