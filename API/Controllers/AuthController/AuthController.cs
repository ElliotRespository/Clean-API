using Application.Commands.User.UserDelete;
using Application.Commands.User.UserRegister;
using Application.Commands.User.UserUpdate;
using Application.Dtos.User;
using Application.Querys.Users;
using Application.Querys.Users.GetAll;
using Application.Querys.Users.Login;
using Application.Validators.User;
using Domain.Models.UserModels;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly UserValidator _userValidator;
        private readonly ILogger<AuthController> _logger;


        public AuthController(IMediator mediatr, UserValidator userValidator, ILogger<AuthController> logger)
        {
            _mediatr = mediatr;
            _userValidator = userValidator;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserInfoDto userToLogin)
        {
            var inputValidation = await _userValidator.ValidateAsync(userToLogin);

            if (!inputValidation.IsValid)
            {
                _logger.LogWarning("Login validation failed for user: {Username}", userToLogin.Username);
                return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                string token = await _mediatr.Send(new LoginQuery(userToLogin));
                _logger.LogInformation("User logged in successfully: {Username}", userToLogin.Username);
                return Ok(new TokenDto { TokenValue = token });
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e, "Unauthorized login attempt for user: {Username}", userToLogin.Username);
                return Unauthorized(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserInfoDto userToRegister)
        {
            var inputValidation = await _userValidator.ValidateAsync(userToRegister);

            if (!inputValidation.IsValid)
            {
                _logger.LogWarning("Registration validation failed");
                return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                UserModel registeredUser = await _mediatr.Send(new RegisterUserCommand(userToRegister));
                _logger.LogInformation("User registered successfully: {Username}", userToRegister.Username);
                return Ok(registeredUser);
            }
            catch (ArgumentException e)
            {
                _logger.LogError(e, "Error during user registration");
                return BadRequest(e.Message);
            }
        }


        [HttpGet("getAllUsers")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediatr.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        //exempel
        [Authorize(Policy = "Admin")]
        [HttpPut("updateUser/{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UserUpdateDto userUpdateDto)
        {
            var validationResult = await _userValidator.ValidateAsync(userUpdateDto);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Update user validation failed for user: {UserId}", userId);
                return BadRequest(validationResult.Errors);
            }

            try
            {
                UserModel updatedUser = await _mediatr.Send(new UpdateUserCommand(userId, userUpdateDto));
                _logger.LogInformation("User updated successfully: {UserId}", userId);
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, "User not found for update: {UserId}", userId);
                return NotFound(ex.Message);
            }
        }



        [Authorize(Policy = "Admin")]
        [HttpDelete("deleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                await _mediatr.Send(new DeleteUserCommand(userId));
                _logger.LogInformation("User deleted successfully: {UserId}", userId);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, "User not found for deletion: {UserId}", userId);
                return NotFound(ex.Message);
            }
        }

    }
}
