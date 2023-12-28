using API.Controllers.AuthController;
using Application.Commands.User.UserRegister;
using Application.Querys.Users.Login;
using Application.Dtos.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Domain.Models.UserModels;
using Microsoft.Extensions.Logging.Abstractions;
using Application.Validators.User;
using Infrastructure.Repository.Users;

namespace Test.APITests.Controllers
{
    [TestFixture]
    public class AuthControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private Mock<IUserRepository> _userRepositoryMock;
        private AuthController _controller;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _userRepositoryMock = new Mock<IUserRepository>();
            var userValidator = new UserValidator(_userRepositoryMock.Object);
            _controller = new AuthController(_mediatorMock.Object, userValidator, new NullLogger<AuthController>());
        }


        [Test]
        public async Task Register_ShouldReturnOk_WhenRegistrationIsSuccessful()
        {
            var userToRegister = new UserInfoDto { Username = "TestUser", Password = "TestPassword" };
            var registeredUser = new UserModel { Id = Guid.NewGuid(), UserName = userToRegister.Username };

            _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(registeredUser);

            var result = await _controller.Register(userToRegister);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task Register_ShouldReturnBadRequest_WhenRegistrationFails()
        {
            var userToRegister = new UserInfoDto { Username = "TestUser", Password = "TestPassword" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>()))
                         .Throws(new ArgumentException("Registration failed"));

            var result = await _controller.Register(userToRegister);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task Login_ShouldReturnOk_WhenCredentialsAreValid()
        {
            var userToLogin = new UserInfoDto { Username = "TestUser", Password = "TestPassword" };
            var token = "mockJwtToken";

            _mediatorMock.Setup(m => m.Send(It.IsAny<LoginQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(token);

            var result = await _controller.Login(userToLogin);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.Value, Is.TypeOf<TokenDto>());
            var resultToken = okResult?.Value as TokenDto;
            Assert.That(resultToken?.TokenValue, Is.EqualTo(token));
        }

        [Test]
        public async Task Login_ShouldReturnUnauthorized_WhenCredentialsAreInvalid()
        {
            var userToLogin = new UserInfoDto { Username = "TestUser", Password = "TestPassword" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<LoginQuery>(), It.IsAny<CancellationToken>()))
                         .ThrowsAsync(new ArgumentException("Unauthorized login attempt for user"));

            var result = await _controller.Login(userToLogin);

            Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
            var unauthorizedResult = result as UnauthorizedObjectResult;
            Assert.That(unauthorizedResult?.Value, Is.EqualTo("Unauthorized login attempt for user"));

        }


    }
}
