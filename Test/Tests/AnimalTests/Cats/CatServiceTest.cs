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
using NUnit.Framework.Legacy;

namespace YourNamespace.Tests
{
    [TestFixture]
    public class CatServiceTests
    {
        private Mock<IAnimalRepository> _mockRepo;
        private CatService _catService;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IAnimalRepository>();
            _catService = new CatService(_mockRepo.Object);
        }

        [Test]
        public async Task CreateCatAsync_ShouldReturnCreatedCat()
        {
            //Arrange
            var catDto = new AnimalDto { Name = "TestCat", Breed = "Bengal", Weight = 10, Color = "Brown" };
            var expectedCat = new Cat { AnimalID = Guid.NewGuid(), Name = "TestCat", Breed = "Bengal", Weight = 10, Color = "Brown" };
            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Cat>()))
                    .Callback<Cat>(cat => cat.AnimalID = expectedCat.AnimalID)
                    .Returns(Task.CompletedTask);
            //Act
            var result = await _catService.CreateCatAsync(catDto);
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(expectedCat.Name));
            Assert.That(result.Breed, Is.EqualTo(expectedCat.Breed));
            Assert.That(result.Weight, Is.EqualTo(expectedCat.Weight));
            Assert.That(result.Color, Is.EqualTo(expectedCat.Color));
            Assert.That(result.AnimalID, Is.EqualTo(expectedCat.AnimalID));
        }

        [Test]
        public void CreateCatAsync_WhenRepositoryThrowsException_ShouldRethrow()
        {
            // Arrange
            var catDto = new AnimalDto { Name = "TestCat", Breed = "Bengal", Weight = 10, Color = "Brown" };
            _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Cat>())).ThrowsAsync(new InvalidOperationException("Test exception"));

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _catService.CreateCatAsync(catDto));
        }


        [Test]
        public async Task GetCatByIdAsync_WhenCatExists_ShouldReturnCat()
        {
            //Arrange
            var catId = Guid.NewGuid();
            var expectedCat = new Cat { AnimalID = catId, Name = "TestCat", Breed = "Bengal", Weight = 10, Color = "Brown" };
            _mockRepo.Setup(repo => repo.GetCatByIdAsync(catId)).ReturnsAsync(expectedCat);
            //Act
            var result = await _catService.GetCatByIdAsync(catId);
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expectedCat));
        }

        [Test]
        public async Task GetCatByIdAsync_WhenCatNotFound_ShouldReturnNull()
        {
            // Arrange
            var catId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.GetCatByIdAsync(catId)).ReturnsAsync((Cat)null);

            // Act
            var result = await _catService.GetCatByIdAsync(catId);

            // Assert
            Assert.That(result, Is.Null);
        }


        [Test]
        public async Task GetAllCatsAsync_ShouldReturnAllCats()
        {
            //Arrange
            var cats = new List<Cat> { new Cat { AnimalID = Guid.NewGuid(), Name = "TestCat1" }, new Cat { AnimalID = Guid.NewGuid(), Name = "TestCat2" } };
            _mockRepo.Setup(repo => repo.GetAllCatsAsync()).ReturnsAsync(cats);
            //Act
            var result = await _catService.GetAllCatsAsync();
            //Assert
            Assert.That(result.Count, Is.EqualTo(cats.Count));
            Assert.That(result, Is.EquivalentTo(cats));
        }


        [Test]
        public async Task UpdateCatAsync_ShouldUpdateCat()
        {
            // Arrange
            var catId = Guid.NewGuid();
            var catDto = new AnimalDto { Name = "UpdatedCat", Breed = "Siamese", Weight = 8, Color = "White" };
            var existingCat = new Cat { AnimalID = catId, Name = "TestCat", Breed = "Bengal", Weight = 10, Color = "Brown" };
            _mockRepo.Setup(repo => repo.GetCatByIdAsync(catId)).ReturnsAsync(existingCat);
            _mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Cat>())).Returns(Task.CompletedTask);

            // Act
            await _catService.UpdateCatAsync(catId, catDto);

            // Assert
            _mockRepo.Verify(repo => repo.UpdateAsync(It.Is<Cat>(cat => cat.AnimalID == catId
            && cat.Name == catDto.Name
            && cat.Breed == catDto.Breed
            && cat.Weight == catDto.Weight
            && cat.Color == catDto.Color)),
            Times.Once());
        }

        [Test]
        public void UpdateCatAsync_WhenCatNotFound_ShouldThrowException()
        {
            // Arrange
            var catId = Guid.NewGuid();
            var catDto = new AnimalDto { Name = "UpdatedCat", Breed = "Siamese", Weight = 8, Color = "White" };
            _mockRepo.Setup(repo => repo.GetCatByIdAsync(catId)).ReturnsAsync((Cat)null);

            // Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => _catService.UpdateCatAsync(catId, catDto));
        }



        [Test]
        public async Task DeleteCatAsync_WhenCatExists_ShouldDeleteCat()
        {
            // Arrange
            var catId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.DeleteAsync<Cat>(catId)).Returns(Task.CompletedTask);

            // Act
            await _catService.DeleteCatAsync(catId);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteAsync<Cat>(catId), Times.Once());
        }

        [Test]
        public void DeleteCatAsync_WhenCatNotFound_ShouldNotThrow()
        {
            // Arrange
            var catId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.DeleteAsync<Cat>(catId)).Returns(Task.CompletedTask);

            // Act & Assert
            Assert.DoesNotThrowAsync(async () => await _catService.DeleteCatAsync(catId));
        }

    }
}
