using NUnit.Framework;
using Moq;
using Application.Services.UserAnimal;
using Domain.Models;
using Infrastructure.Repository.UserAnimal;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Application.Services.UserAnimalService;
using Application.Dtos.UserAnimal;

namespace Test.Tests.UserAnimalTests
{
    [TestFixture]
    public class UserAnimalServiceTest
    {
        private Mock<IUserAnimalRepository> _mockRepo;
        private UserAnimalService _userAnimalService;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IUserAnimalRepository>();
            _userAnimalService = new UserAnimalService(_mockRepo.Object);
        }

        [Test]
        public async Task CreateUserAnimalAsync_ShouldReturnCreatedUserAnimalId()
        {
            // Arrange
            var userAnimalDto = new UserAnimalDto { UserId = Guid.NewGuid(), AnimalId = Guid.NewGuid() };
            var expectedUserAnimalId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.CreateUserAnimal(It.IsAny<UserAnimalModel>()))
                    .ReturnsAsync(expectedUserAnimalId);

            // Act
            var result = await _userAnimalService.CreateUserAnimalAsync(userAnimalDto);

            // Assert
            Assert.That(result, Is.EqualTo(expectedUserAnimalId));
        }

        [Test]
        public void CreateUserAnimalAsync_WhenRepositoryThrows_ShouldRethrow()
        {
            // Arrange
            var userAnimalDto = new UserAnimalDto { UserId = Guid.NewGuid(), AnimalId = Guid.NewGuid() };
            _mockRepo.Setup(repo => repo.CreateUserAnimal(It.IsAny<UserAnimalModel>()))
                     .ThrowsAsync(new InvalidOperationException("Test exception"));

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _userAnimalService.CreateUserAnimalAsync(userAnimalDto));
        }

        [Test]
        public async Task GetUserAnimalByIdAsync_WhenUserAnimalExists_ShouldReturnUserAnimal()
        {
            // Arrange
            var userAnimalId = Guid.NewGuid();
            var expectedUserId = Guid.NewGuid();
            var expectedAnimalId = Guid.NewGuid();
            var expectedUserAnimal = new UserAnimalModel
            {
                UserAnimalId = userAnimalId,
                UserId = expectedUserId,
                AnimalId = expectedAnimalId
            };
            _mockRepo.Setup(repo => repo.GetUserAnimalById(userAnimalId)).ReturnsAsync(expectedUserAnimal);

            // Act
            var result = await _userAnimalService.GetUserAnimalByIdAsync(userAnimalId);

            // Assert
            Assert.That(result.UserId, Is.EqualTo(expectedUserId));
            Assert.That(result.AnimalId, Is.EqualTo(expectedAnimalId));
        }

        [Test]
        public void GetUserAnimalByIdAsync_WhenRepositoryThrows_ShouldRethrow()
        {
            // Arrange
            var userAnimalId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.GetUserAnimalById(userAnimalId))
                     .ThrowsAsync(new InvalidOperationException("Test exception"));

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _userAnimalService.GetUserAnimalByIdAsync(userAnimalId));
        }

        [Test]
        public async Task UpdateUserAnimalAsync_ShouldCallUpdate()
        {
            // Arrange
            var userAnimalId = Guid.NewGuid();
            var updateDto = new UpdateUserAnimalDto { UserAnimalId = userAnimalId, NewUserId = Guid.NewGuid(), NewAnimalId = Guid.NewGuid() };
            var existingUserAnimal = new UserAnimalModel { UserAnimalId = userAnimalId, UserId = Guid.NewGuid(), AnimalId = Guid.NewGuid() };

            _mockRepo.Setup(repo => repo.GetUserAnimalById(userAnimalId)).ReturnsAsync(existingUserAnimal);
            _mockRepo.Setup(repo => repo.UpdateUserAnimal(It.IsAny<UserAnimalModel>())).Returns(Task.CompletedTask);

            // Act
            await _userAnimalService.UpdateUserAnimalAsync(updateDto);

            // Assert
            _mockRepo.Verify(repo => repo.UpdateUserAnimal(It.IsAny<UserAnimalModel>()), Times.Once());
        }


        [Test]
        public void UpdateUserAnimalAsync_WhenRepositoryThrows_ShouldRethrow()
        {
            // Arrange
            var updateDto = new UpdateUserAnimalDto { UserAnimalId = Guid.NewGuid(), NewUserId = Guid.NewGuid(), NewAnimalId = Guid.NewGuid() };
            _mockRepo.Setup(repo => repo.UpdateUserAnimal(It.IsAny<UserAnimalModel>()))
                     .ThrowsAsync(new InvalidOperationException("Test exception"));

            // Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => _userAnimalService.UpdateUserAnimalAsync(updateDto));
        }



        [Test]
        public async Task DeleteUserAnimalAsync_WhenUserAnimalExists_ShouldDeleteUserAnimal()
        {
            // Arrange
            var userAnimalId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.DeleteUserAnimal(userAnimalId)).Returns(Task.CompletedTask);

            // Act
            await _userAnimalService.DeleteUserAnimalAsync(userAnimalId);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteUserAnimal(userAnimalId), Times.Once());
        }

        [Test]
        public void DeleteUserAnimalAsync_WhenRepositoryThrows_ShouldRethrow()
        {
            // Arrange
            var userAnimalId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.DeleteUserAnimal(userAnimalId))
                     .ThrowsAsync(new InvalidOperationException("Test exception"));

            // Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _userAnimalService.DeleteUserAnimalAsync(userAnimalId));
        }

    }
}
