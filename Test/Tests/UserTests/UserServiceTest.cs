#nullable disable
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.User;
using Domain.Models.UserModels;
using Infrastructure.Repository.Users;
using Application.Dtos.User;
using Application.Services.PasswordHasher;
using FluentValidation;
using FluentValidation.Results;

namespace YourNamespace.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _mockUserRepo;
        private Mock<IPasswordHasher> _mockPasswordHasher;
        private Mock<IValidator<UserInfoDto>> _mockValidator;
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            _mockUserRepo = new Mock<IUserRepository>();
            _mockPasswordHasher = new Mock<IPasswordHasher>();
            _mockValidator = new Mock<IValidator<UserInfoDto>>();
            _userService = new UserService(_mockUserRepo.Object, _mockPasswordHasher.Object, _mockValidator.Object);

            // Mock Password Hasher
            _mockPasswordHasher.Setup(hasher => hasher.HashPassword(It.IsAny<string>())).Returns("HashedPassword");

            // Mock Validator för att returnera en successful validation
            var validationResults = new ValidationResult();
            _mockValidator.Setup(validator => validator.ValidateAsync(It.IsAny<UserInfoDto>(), default)).ReturnsAsync(validationResults);
        }

        [Test]
        public async Task RegisterUserAsync_ShouldCreateNewUser()
        {
            // Arrange
            var userInfoDto = new UserInfoDto { Username = "NewUser", Password = "SecurePassword123!" };
            var newUser = new UserModel { Id = Guid.NewGuid(), UserName = userInfoDto.Username, Password = "HashedPassword" };
            _mockUserRepo.Setup(repo => repo.RegisterUserAsync(It.IsAny<UserModel>()))
                         .ReturnsAsync(newUser);

            // Act
            var result = await _userService.RegisterUserAsync(userInfoDto);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.UserName, Is.EqualTo(newUser.UserName));
            Assert.That(result.Id, Is.EqualTo(newUser.Id));
        }

        [Test]
        public async Task GetUserByIdAsync_ShouldReturnUser()
        {
            var userId = Guid.NewGuid();
            var expectedUser = new UserModel { Id = userId, UserName = "ExistingUser", Password = "ExistingPassword" };
            _mockUserRepo.Setup(repo => repo.GetUserByIdAsync(userId))
                         .ReturnsAsync(expectedUser);

            var result = await _userService.GetUserByIdAsync(userId);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.UserName, Is.EqualTo(expectedUser.UserName));
            Assert.That(result.Id, Is.EqualTo(expectedUser.Id));
        }

        [Test]
        public async Task UpdateUserAsync_ShouldUpdateUser()
        {
            var userId = Guid.NewGuid();
            var userUpdateDto = new UserUpdateDto { Username = "UpdatedUser", Password = "UpdatedPassword" };
            var existingUser = new UserModel { Id = userId, UserName = "OriginalUser", Password = "OriginalPassword" };
            _mockUserRepo.Setup(repo => repo.GetUserByIdAsync(userId))
                         .ReturnsAsync(existingUser);
            _mockUserRepo.Setup(repo => repo.UpdateUserAsync(It.IsAny<UserModel>()))
                         .Returns(Task.CompletedTask);

            await _userService.UpdateUserAsync(userId, userUpdateDto);

            _mockUserRepo.Verify(repo => repo.UpdateUserAsync(It.Is<UserModel>(user =>
                user.Id == userId &&
                user.UserName == userUpdateDto.Username)),
                Times.Once());
        }

        [Test]
        public void UpdateUserAsync_WhenUserNotFound_ShouldThrowException()
        {
            var userId = Guid.NewGuid();
            var userUpdateDto = new UserUpdateDto { Username = "NonExistingUser", Password = "NewPassword" };
            _mockUserRepo.Setup(repo => repo.GetUserByIdAsync(userId))
                         .ReturnsAsync((UserModel)null);

            Assert.ThrowsAsync<KeyNotFoundException>(() => _userService.UpdateUserAsync(userId, userUpdateDto));
        }

        [Test]
        public async Task DeleteUserAsync_WhenUserExists_ShouldDeleteUser()
        {
            var userId = Guid.NewGuid();
            _mockUserRepo.Setup(repo => repo.DeleteUserAsync(userId))
                         .Returns(Task.CompletedTask);

            await _userService.DeleteUserAsync(userId);

            _mockUserRepo.Verify(repo => repo.DeleteUserAsync(userId), Times.Once());
        }

        [Test]
        public void DeleteUserAsync_WhenUserNotFound_ShouldThrowException()
        {
            var userId = Guid.NewGuid();
            _mockUserRepo.Setup(repo => repo.DeleteUserAsync(userId))
                         .ThrowsAsync(new ArgumentException("User not found"));

            Assert.ThrowsAsync<ArgumentException>(() => _userService.DeleteUserAsync(userId));
        }
    }
}
