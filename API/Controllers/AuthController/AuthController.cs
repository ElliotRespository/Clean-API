using Application.Commands.User.UserDelete;
using Application.Commands.User.UserRegister;
using Application.Commands.User.UserUpdate;
using Application.Dtos.User;
using Application.Exceptions.Authorize;
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
        internal readonly IMediator _mediatr;
        internal readonly UserValidator _userValidator;
        internal readonly UserUpdateValidator _userUpdateValidator;

        public AuthController(IMediator mediatr, UserValidator userValidator, UserUpdateValidator userUpdateValidator)
        {
            _mediatr = mediatr;
            _userValidator = userValidator;
            _userUpdateValidator = userUpdateValidator;

        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserInfoDto userToLogin)
        {
            var inputValidation = _userValidator.Validate(userToLogin);

            if (!inputValidation.IsValid)
            {
                return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                string token = await _mediatr.Send(new LoginQuery(userToLogin));

                return Ok(new TokenDto { TokenValue = token });
            }
            catch (UnAuthorizedException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] UserInfoDto userToRegister)
        {
            var inputValidation = _userValidator.Validate(userToRegister);

            if (!inputValidation.IsValid)
            {
                return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatr.Send(new RegisterUserCommand(userToRegister)));
            }
            catch (ArgumentException e)
            {

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

        [HttpPut("updateUser/{userId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid userId, [FromBody] UserUpdateDto userUpdateDto)
        {
            var validationResult = _userUpdateValidator.Validate(userUpdateDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var updateUserCommand = new UpdateUserCommand(userId, userUpdateDto);

            try
            {
                UserModel updatedUser = await _mediatr.Send(updateUserCommand);

                if (updatedUser == null)
                {
                    return NoContent();
                }

                var result = new
                {
                    Username = updatedUser.UserName,
                };

                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("deleteUser/{userId}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                // Anropa UserRepository för att ta bort användaren
                await _mediatr.Send(new DeleteUserCommand(userId));

                // Returnera en respons för att indikera att användaren har raderats
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                // Hantera fel här om användaren inte hittas
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Hantera andra fel här
                return BadRequest(ex.Message);
            }
        }




    }
}
