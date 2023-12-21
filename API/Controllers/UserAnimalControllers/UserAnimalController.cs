using Application.Commands.UserAnimal.Create;
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
        private readonly UpdateUserAnimalDtoValidator _updateValidator;

        public UserAnimalController(IMediator mediator, UserAnimalValidator validator, UpdateUserAnimalDtoValidator updateValidator)
        {
            _mediator = mediator;
            _validator = validator;
            _updateValidator = updateValidator;
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
            try
            {
                var validationResult = _validator.Validate(userAnimalDto);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var command = new CreateUserAnimalCommand { UserAnimalDto = userAnimalDto };
                var createdUserId = await _mediator.Send(command);

                return Ok(createdUserId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating UserAnimal: {ex.Message}");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUserAnimal(UpdateUserAnimalDto updateDto)
        {
            try
            {
                // Validera indata
                var validationResult = new UpdateUserAnimalDtoValidator().Validate(updateDto);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                // Skapa och skicka kommandot för att uppdatera UserAnimal
                var command = new UpdateUserAnimalCommand { UpdateUserAnimalDto = updateDto };
                var result = await _mediator.Send(command);

                // Om uppdateringen lyckas, returnera den uppdaterade UserAnimal
                if (result != null)
                {
                    return Ok(new { message = "UserAnimal updated successfully.", userAnimal = result });
                }
                else
                {
                    return NotFound(new { message = "UserAnimal not found." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error updating UserAnimal: {ex.Message}" });
            }
        }



    }
}
