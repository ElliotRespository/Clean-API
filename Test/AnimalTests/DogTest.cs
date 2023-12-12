using Infrastructure.Database;
using Application.Commands.Dogs.CreateDog;
using Application.Querys.Dogs.GetAllDogs;
using Application.Commands.Dogs.UpdateDog;
using Application.Commands.Dogs.DeleteDog;
using Application.Querys.Dogs.GetDogById;
using Domain.Models.Animalmodels;
using Application.Dtos;

namespace Test.AnimalTests
{
    [TestFixture]
    public class DogTest
    {
        [Test]
        public async Task Handle_ShouldReturnAllDogs()
        {
            // Arrange
            var mockDatabase = new MockDatabase();
            mockDatabase.allDogs = new List<Dog>
        {
            new Dog { animalID = Guid.NewGuid(), Name = "Doggo" },
            new Dog { animalID = Guid.NewGuid(), Name = "Raggy" }
        };
            var handler = new GetAllDogsQueryHandler(mockDatabase);

            // Act
            var result = await handler.Handle(new GetAllDogsQuery(), CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task Handle_ExistingDogId_ShouldReturnDog()
        {
            // Arrange
            var existingDogId = Guid.NewGuid();
            var mockDatabase = new MockDatabase
            {
                allDogs = new List<Dog> { new Dog { animalID = existingDogId, Name = "Existing Dog" } }
            };
            var handler = new GetDogByIdQueryHandler(mockDatabase);
            var query = new GetDogByIdQuery(existingDogId);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result.animalID, Is.EqualTo(existingDogId));
            Assert.That(result.Name, Is.EqualTo("Existing Dog"));
        }

        [Test]
        public async Task Handle_NonExistingDogId_ShouldReturnNull()
        {
            // Arrange
            var nonExistingDogId = Guid.NewGuid();
            var mockDatabase = new MockDatabase
            {
                allDogs = new List<Dog>() // Ingen hund i databasen
            };
            var handler = new GetDogByIdQueryHandler(mockDatabase);
            var query = new GetDogByIdQuery(nonExistingDogId);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task Handle_GivenValidDog_ShouldCreateDog()
        {
            // Arrange
            var mockDatabase = new MockDatabase();
            var handler = new CreateDogCommandHandler(mockDatabase);
            var command = new CreateDogCommand(new AnimalDto { Name = "New Dog" });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("New Dog"));
        }

        [Test]
        public async Task Handle_GivenExistingDog_ShouldUpdateDog()
        {
            // Arrange
            var dogId = Guid.NewGuid();
            var mockDatabase = new MockDatabase
            {
                allDogs = new List<Dog> { new Dog { animalID = dogId, Name = "Old Name" } }
            };
            var handler = new UpdateDogByIdCommandHandler(mockDatabase);
            var updatedDogDto = new AnimalDto { Name = "Updated Name" };
            var command = new UpdateDogByIdCommand(updatedDogDto, dogId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Updated Name"));
        }

        [Test]
        public void Handle_GivenNonExistingDog_ShouldNotUpdateAndReturnNull()
        {
            // Arrange
            var nonExistingDogId = Guid.NewGuid();
            var mockDatabase = new MockDatabase();
            var handler = new UpdateDogByIdCommandHandler(mockDatabase);
            var updatedDogDto = new AnimalDto { Name = "Updated Name" };
            var command = new UpdateDogByIdCommand(updatedDogDto, nonExistingDogId);

            // Act & Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, CancellationToken.None));
            Assert.That(exception.Message, Is.EqualTo("Dog lyckades inte uppdateras"));
        }


        [Test]
        public async Task Handle_GivenExistingDog_ShouldDeleteDog()
        {
            // Arrange
            var dogId = Guid.NewGuid();
            var mockDatabase = new MockDatabase
            {
                allDogs = new List<Dog> { new Dog { animalID = dogId, Name = "Dog to Delete" } }
            };
            var handler = new DeleteDogByIdCommandHandler(mockDatabase);
            var command = new DeleteDogByIdCommand(dogId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(mockDatabase.allDogs.Any(dog => dog.animalID == dogId), Is.False);
        }

        [Test]
        public void Handle_GivenNonExistingDog_ShouldNotDeleteAndReturnNull()
        {
            // Arrange
            var nonExistingDogId = Guid.NewGuid();
            var mockDatabase = new MockDatabase();
            var handler = new DeleteDogByIdCommandHandler(mockDatabase);
            var command = new DeleteDogByIdCommand(nonExistingDogId);

            // Act & Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, CancellationToken.None));
            Assert.That(exception.Message, Is.EqualTo("Dog lyckades ej deletas"));
        }

    }
}
