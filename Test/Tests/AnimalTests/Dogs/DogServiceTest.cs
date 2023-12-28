#nullable disable
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Animals.Dogs_Cats;
using Domain.Models.Animalmodels;
using Infrastructure.Repository.Animals;
using Application.Dtos.Animal;

namespace YourNamespace.Tests
{
    [TestFixture]
    public class DogServiceTests
    {
        private Mock<IAnimalRepository> _mockRepo;
        private DogService _dogService;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IAnimalRepository>();
            _dogService = new DogService(_mockRepo.Object);
        }

        [Test]
        public async Task CreateDogAsync_ShouldReturnCreatedDog()
        {
            // Arrange
            var dogDto = new AnimalDto { Name = "TestDog", Breed = "Labrador", Weight = 30, Color = "Black" };
            var expectedDog = new Dog { AnimalID = Guid.NewGuid(), Name = "TestDog", Breed = "Labrador", Weight = 30, Color = "Black" };
            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Dog>()))
                     .Callback<Dog>(dog => dog.AnimalID = expectedDog.AnimalID)
                     .Returns(Task.CompletedTask);

            // Act
            var result = await _dogService.CreateDogAsync(dogDto);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(expectedDog.Name));
            Assert.That(result.Breed, Is.EqualTo(expectedDog.Breed));
            Assert.That(result.Weight, Is.EqualTo(expectedDog.Weight));
            Assert.That(result.Color, Is.EqualTo(expectedDog.Color));
            Assert.That(result.AnimalID, Is.EqualTo(expectedDog.AnimalID));
        }

        [Test]
        public void CreateDogAsync_WhenRepositoryThrowsException_ShouldRethrow()
        {
            // Arrange
            var dogDto = new AnimalDto { Name = "TestDog", Breed = "Labrador", Weight = 30, Color = "Black" };
            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Dog>()))
                     .ThrowsAsync(new InvalidOperationException("Test exception"));

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _dogService.CreateDogAsync(dogDto));
        }


        [Test]
        public async Task GetDogByIdAsync_WhenDogExists_ShouldReturnDog()
        {
            // Arrange
            var dogId = Guid.NewGuid();
            var expectedDog = new Dog { AnimalID = dogId, Name = "TestDog", Breed = "Labrador", Weight = 30, Color = "Black" };
            _mockRepo.Setup(repo => repo.GetDogByIdAsync(dogId)).ReturnsAsync(expectedDog);

            // Act
            var result = await _dogService.GetDogByIdAsync(dogId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expectedDog));
        }

        [Test]
        public async Task GetDogByIdAsync_WhenDogNotFound_ShouldReturnNull()
        {
            // Arrange
            var dogId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.GetDogByIdAsync(dogId)).ReturnsAsync((Dog)null);

            // Act
            var result = await _dogService.GetDogByIdAsync(dogId);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetAllDogsAsync_ShouldReturnAllDogs()
        {
            // Arrange
            var dogs = new List<Dog> { new Dog { AnimalID = Guid.NewGuid(), Name = "TestDog1" }, new Dog { AnimalID = Guid.NewGuid(), Name = "TestDog2" } };
            _mockRepo.Setup(repo => repo.GetAllDogsAsync()).ReturnsAsync(dogs);

            // Act
            var result = await _dogService.GetAllDogsAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(dogs.Count));
            Assert.That(result, Is.EquivalentTo(dogs));
        }

        [Test]
        public async Task UpdateDogAsync_ShouldUpdateDog()
        {
            // Arrange
            var dogId = Guid.NewGuid();
            var dogDto = new AnimalDto { Name = "UpdatedDog", Breed = "Husky", Weight = 20, Color = "Grey" };
            var existingDog = new Dog { AnimalID = dogId, Name = "TestDog", Breed = "Labrador", Weight = 30, Color = "Black" };
            _mockRepo.Setup(repo => repo.GetDogByIdAsync(dogId)).ReturnsAsync(existingDog);
            _mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Dog>())).Returns(Task.CompletedTask);

            // Act
            await _dogService.UpdateDogAsync(dogId, dogDto);

            // Assert
            _mockRepo.Verify(repo => repo.UpdateAsync(It.Is<Dog>(d => d.AnimalID == dogId
                && d.Name == dogDto.Name
                && d.Breed == dogDto.Breed
                && d.Weight == dogDto.Weight
                && d.Color == dogDto.Color)), Times.Once());
        }

        [Test]
        public void UpdateDogAsync_WhenDogNotFound_ShouldThrowException()
        {
            // Arrange
            var dogId = Guid.NewGuid();
            var dogDto = new AnimalDto { Name = "UpdatedDog", Breed = "Husky", Weight = 20, Color = "Grey" };
            _mockRepo.Setup(repo => repo.GetDogByIdAsync(dogId)).ReturnsAsync((Dog)null);

            // Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => _dogService.UpdateDogAsync(dogId, dogDto));
        }


        [Test]
        public async Task DeleteDogAsync_WhenDogExists_ShouldDeleteDog()
        {
            // Arrange
            var dogId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.DeleteAsync<Dog>(dogId)).Returns(Task.CompletedTask);

            // Act
            await _dogService.DeleteDogAsync(dogId);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteAsync<Dog>(dogId), Times.Once());
        }

        [Test]
        public void DeleteDogAsync_WhenDogNotFound_ShouldThrowException()
        {
            // Arrange
            var dogId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.GetDogByIdAsync(dogId)).ReturnsAsync((Dog)null);

            // Act & Assert
            Assert.DoesNotThrowAsync(async () => await _dogService.DeleteDogAsync(dogId));
        }

    }
}
