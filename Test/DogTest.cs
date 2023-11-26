using System;
using NUnit.Framework;
using Moq;
using Infrastructure.Database;
using Application.Commands.Dogs.CreateDog;
using Application.Dtos.Dogdto;
using Application.Querys.Dogs.GetAllDogs;
using Domain.Models;
using Application.Commands.Dogs.UpdateDog;
using Application.Commands.Dogs.DeleteDog;
using Application.Querys.Dogs.GetDogById;

namespace Test
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
            Assert.IsNotNull(result);
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
            Assert.IsNull(result);
        }

        [Test]
        public async Task Handle_GivenValidDog_ShouldCreateDog()
        {
            // Arrange
            var mockDatabase = new MockDatabase();
            var handler = new CreateDogCommandHandler(mockDatabase);
            var dogDto = new DogDto { Name = "New Dog" };
            var command = new CreateDogCommand { Dog = dogDto };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(dogDto.Name));
            Assert.That(result.animalID, Is.Not.EqualTo(Guid.Empty));
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
            var updatedDogDto = new DogDto { Name = "Updated Name" };
            var command = new UpdateDogByIdCommand(updatedDogDto, dogId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo("Updated Name"));
        }

        [Test]
        public async Task Handle_GivenNonExistingDog_ShouldNotUpdateAndReturnNull()
        {
            // Arrange
            var nonExistingDogId = Guid.NewGuid();
            var mockDatabase = new MockDatabase
            {
                allDogs = new List<Dog>() 
            };
            var handler = new UpdateDogByIdCommandHandler(mockDatabase);
            var updatedDogDto = new DogDto { Name = "Updated Name" };
            var command = new UpdateDogByIdCommand(updatedDogDto, nonExistingDogId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
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
            Assert.IsNotNull(result);
            Assert.IsEmpty(mockDatabase.allDogs);
        }

        [Test]
        public async Task Handle_GivenNonExistingDog_ShouldNotDeleteAndReturnNull()
        {
            // Arrange
            var nonExistingDogId = Guid.NewGuid();
            var mockDatabase = new MockDatabase
            {
                allDogs = new List<Dog>() 
            };
            var handler = new DeleteDogByIdCommandHandler(mockDatabase);
            var command = new DeleteDogByIdCommand(nonExistingDogId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }

    }
}
