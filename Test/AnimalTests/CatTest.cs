using System;
using NUnit.Framework;
using Moq;
using Infrastructure.Database;
using Domain.Models.Animalmodels;
using Application.Dtos;
using Application.Querys.Cats;
using Application.Querys.Cats.GetAllCats;
using Application.Querys.Cats.GetCatById;
using Application.Commands.Cats.CreateCat;
using Application.Commands.Cats.UpdateCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Dogs.UpdateDog;

namespace Test.AnimalTests
{
    [TestFixture]
    public class CatTest
    {
        [Test]
        public async Task Handle_ShouldReturnAllCats()
        {
            // Arrange
            var mockDatabase = new MockDatabase();
            mockDatabase.allCats = new List<Cat>
        {
            new Cat { animalID = Guid.NewGuid(), Name = "Mr Whiskers" },
            new Cat { animalID = Guid.NewGuid(), Name = "Ragdolian" }
        };
            var handler = new GetAllCatsQueryHandler(mockDatabase);

            // Act
            var result = await handler.Handle(new GetAllCatsQuery(), CancellationToken.None);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task Handle_ExistingCatId_ShouldReturnCat()
        {
            // Arrange
            var existingCatId = Guid.NewGuid();
            var mockDatabase = new MockDatabase
            {
                allCats = new List<Cat> { new Cat { animalID = existingCatId, Name = "Existing Cat" } }
            };
            var handler = new GetCatByIdQueryHandler(mockDatabase);
            var query = new GetCatByIdQuery(existingCatId);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result.animalID, Is.EqualTo(existingCatId));
            Assert.That(result.Name, Is.EqualTo("Existing Cat"));
        }

        [Test]
        public async Task Handle_NonExistingCatId_ShouldReturnNull()
        {
            // Arrange
            var nonExistingCatId = Guid.NewGuid();
            var mockDatabase = new MockDatabase
            {
                allCats = new List<Cat>()
            };
            var handler = new GetCatByIdQueryHandler(mockDatabase);
            var query = new GetCatByIdQuery(nonExistingCatId);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task Handle_GivenValidCat_ShouldCreateCat()
        {
            // Arrange
            var mockDatabase = new MockDatabase();
            var handler = new CreateCatCommandHandler(mockDatabase);
            var catDto = new AnimalDto { Name = "New Cat" };
            var command = new CreateCatCommand { Cat = catDto };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(catDto.Name));
            Assert.That(result.animalID, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public async Task Handle_GivenExistingCat_ShouldUpdateCat()
        {
            // Arrange
            var catId = Guid.NewGuid();
            var mockDatabase = new MockDatabase
            {
                allCats = new List<Cat> { new Cat { animalID = catId, Name = "Old Name" } }
            };
            var handler = new UpdateCatByIdCommandHandler(mockDatabase);
            var updatedCatDto = new AnimalDto { Name = "Updated Name" };
            var command = new UpdateCatByIdCommand(updatedCatDto, catId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Updated Name"));
        }

        [Test]
        public void Handle_GivenNonExistingCat_ShouldNotUpdateAndReturnNull()
        {
            // Arrange
            var nonExistingCatId = Guid.NewGuid();
            var mockDatabase = new MockDatabase();
            var handler = new UpdateCatByIdCommandHandler(mockDatabase);
            var updatedCatDto = new AnimalDto { Name = "Updated Name" };
            var command = new UpdateCatByIdCommand(updatedCatDto, nonExistingCatId);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Is.EqualTo("Cat lyckades inte updateras"));
        }


        [Test]
        public async Task Handle_GivenExistingCat_ShouldDeleteCat()
        {
            // Arrange
            var catId = Guid.NewGuid();
            var mockDatabase = new MockDatabase
            {
                allCats = new List<Cat> { new Cat { animalID = catId, Name = "Cat to Delete" } }
            };
            var handler = new DeleteCatByIdCommandHandler(mockDatabase);
            var command = new DeleteCatByIdCommand(catId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(mockDatabase.allCats.Any(cat => cat.animalID == catId), Is.False);
        }

        [Test]
        public void Handle_GivenNonExistingCat_ShouldNotDeleteAndReturnNull()
        {
            // Arrange
            var nonExistingCatId = Guid.NewGuid();
            var mockDatabase = new MockDatabase();
            var handler = new DeleteCatByIdCommandHandler(mockDatabase);
            var command = new DeleteCatByIdCommand(nonExistingCatId);

            // Act & Assert
            var ex = Assert.ThrowsAsync<Exception>(async() => await handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Is.EqualTo("Cat lyckades inte deletas"));
        }

    }
}

