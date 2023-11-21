using Domain.Models;
using Infrastructure.Database;
using MediatR;


namespace Application.Commands.Dogs.UpdateDog
{
    public class UpdateDogCommanderHandler : IRequestHandler<UpdateDogCommander, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public UpdateDogCommanderHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(UpdateDogCommander request, CancellationToken cancellationToken)
        {
            var dogToUpdate = _mockDatabase.allDogs.FirstOrDefault(dog => dog.animalID == request.AnimalID);
            if (dogToUpdate != null)
            {
                dogToUpdate.Name = request.Name;

            }
            return Task.FromResult(dogToUpdate);


        }
    }
}
