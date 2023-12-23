using Application.Commands.UserAnimal.Create;
using Application.Commands.UserAnimal.Delete;
using Application.Commands.UserAnimal.Update;
using Application.Dtos.UserAnimal;
using Application.Querys.UserAnimals.GetAllUserAnimals;
using Application.Validators.UserAnimal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.UserAnimalControllers
{
    [Route("api/useranimal")]
    [ApiController]
    public class UserAnimalController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserAnimalValidator _validator;
        private readonly ILogger<UserAnimalController> _logger;

        public UserAnimalController(IMediator mediator, UserAnimalValidator validator, ILogger<UserAnimalController> logger)
        {
            _mediator = mediator;
            _validator = validator;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllUserAnimals()
        {
            var query = new GetAllUserAnimalsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserAnimal(UserAnimalDto userAnimalDto)
        {
            var validationResult = await _validator.ValidateAsync(userAnimalDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var command = new CreateUserAnimalCommand(userAnimalDto);
                var createdUserId = await _mediator.Send(command);
                _logger.LogInformation($"UserAnimal with ID {createdUserId} was successfully created.");
                return Ok(createdUserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred creating UserAnimal.");
                return BadRequest($"Error creating UserAnimal: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserAnimal(UpdateUserAnimalDto updateDto)
        {
            var validationResult = await _validator.ValidateAsync(new UserAnimalDto
            {
                UserId = updateDto.NewUserId ?? Guid.Empty,
                AnimalId = updateDto.NewAnimalId ?? Guid.Empty
            });

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var command = new UpdateUserAnimalCommand(updateDto);
                await _mediator.Send(command);
                _logger.LogInformation($"UserAnimal with ID {updateDto.UserAnimalId} was successfully updated.");
                return Ok(new { message = "UserAnimal updated successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred updating UserAnimal with ID {updateDto.UserAnimalId}.");
                return BadRequest(new { message = $"Error updating UserAnimal: {ex.Message}" });
            }
        }



        [HttpDelete("delete/{userAnimalId}")]
        public async Task<IActionResult> DeleteUserAnimal(Guid userAnimalId)
        {
            try
            {
                var command = new DeleteUserAnimalCommand(userAnimalId);
                await _mediator.Send(command);
                _logger.LogInformation($"UserAnimal with ID {userAnimalId} was successfully deleted.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred deleting UserAnimal with ID {userAnimalId}.");
                return BadRequest(new { message = $"Error deleting UserAnimal: {ex.Message}" });
            }
        }
    }
}
