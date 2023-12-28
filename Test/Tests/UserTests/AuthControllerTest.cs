//using API.Controllers.AuthController;
//using Application.Commands.User.UserDelete;
//using Application.Commands.User.UserRegister;
//using Application.Commands.User.UserUpdate;
//using Application.Dtos.User;
//using Application.Querys.Users.GetAll;
//using Application.Querys.Users.Login;
//using Application.Validators.User;
//using Domain.Models.UserModels;
//using FluentValidation.Results;
//using Infrastructure.Repository.Users;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging.Abstractions;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Threading.Tasks;

//namespace Test.APITests.Controllers
//{
//    [TestFixture]
//    public class AuthControllerTests
//    {
//        private Mock<IMediator> _mediatorMock;
//        private AuthController _controller;

//        [SetUp]
//        public void Setup()
//        {
//            _mediatorMock = new Mock<IMediator>();
//            var logger = new NullLogger<AuthController>();

//            var mockUserRepository = new Mock<IUserRepository>();
//            var userValidator = new UserValidator(mockUserRepository.Object);
//            var validationResult = new ValidationResult();
//            mockUserRepository.Setup(r => r.GetAllUsersAsync())
//                              .ReturnsAsync(new List<UserModel>());
//            _controller = new AuthController(_mediatorMock.Object, userValidator, logger);
//        }

//        [Test]
//        public async Task Register_ShouldReturnOk_WhenRegistrationIsSuccessful()
//        {
//            var userToRegister = new UserInfoDto { Username = "TestUser", Password = "TestPassword" };
//            var registeredUser = new UserModel { Id = Guid.NewGuid(), UserName = "TestUser" };

//            _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>()))
//                         .ReturnsAsync(registeredUser);

//            var result = await _controller.Register(userToRegister);

//            Assert.That(result, Is.InstanceOf<OkObjectResult>());
//        }

//        [Test]
//        public async Task Login_ShouldReturnOk_WhenCredentialsAreValid()
//        {
//            var userToLogin = new UserInfoDto { Username = "TestUser", Password = "TestPassword" };
//            var tokenDto = new TokenDto { TokenValue = "mockJwtToken" };

//            _mediatorMock.Setup(m => m.Send(It.IsAny<LoginQuery>(), It.IsAny<CancellationToken>()))
//                         .ReturnsAsync(tokenDto);

//            var result = await _controller.Login(userToLogin);

//            Assert.That(result, Is.InstanceOf<OkObjectResult>());
//            var okResult = result as OkObjectResult;
//            Assert.That(okResult?.Value, Is.InstanceOf<TokenDto>());
//            var resultToken = okResult?.Value as TokenDto;
//            Assert.That(resultToken?.TokenValue, Is.EqualTo(tokenDto.TokenValue));
//        }



//        [Test]
//        public async Task GetAllUsers_ShouldReturnOk_WithListOfUsers()
//        {
//            var users = new List<UserModel> { new UserModel { Id = Guid.NewGuid(), UserName = "User1" } };

//            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllUsersQuery>(), It.IsAny<CancellationToken>()))
//                         .ReturnsAsync(users);

//            var result = await _controller.GetAllUsers();

//            Assert.That(result, Is.InstanceOf<OkObjectResult>());
//            var okResult = result as OkObjectResult;
//            Assert.That(okResult?.Value, Is.EquivalentTo(users));
//        }

//        [Test]
//        public async Task UpdateUser_ShouldReturnOk_WhenUpdateIsSuccessful()
//        {
//            var userId = Guid.NewGuid();
//            var userUpdateDto = new UserUpdateDto { Username = "UpdatedUser", Password = "UpdatedPassword" };
//            var updatedUser = new UserModel { Id = userId, UserName = "UpdatedUser" };

//            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
//                         .ReturnsAsync(updatedUser);

//            var result = await _controller.UpdateUser(userId, userUpdateDto);

//            Assert.That(result, Is.InstanceOf<OkObjectResult>());
//        }

//        [Test]
//        public async Task DeleteUser_ShouldReturnNoContent_WhenDeletionIsSuccessful()
//        {
//            var userId = Guid.NewGuid();

//            _mediatorMock.Setup(m => m.Send(It.Is<DeleteUserCommand>(cmd => cmd.UserId == userId), It.IsAny<CancellationToken>()))
//                         .Returns(Task.CompletedTask); 

//            var result = await _controller.DeleteUser(userId);

//            Assert.That(result, Is.InstanceOf<NoContentResult>());
//        }

//    }
//}
