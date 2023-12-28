using Application.Commands.Dogs.CreateDog;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos.Animal;
using Application.Querys.Dogs.GetAllDogs;
using Application.Querys.Dogs.GetDogById;
using Application.Querys.Dogs.GetDogsbyBreedWeightColor;
using Application.Services.Animals.Dogs_Cats;
using Application.Validators.Dog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.AnimalControllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDogService _dogService;
        private readonly DogValidator _dogValidator;

        public DogsController(IMediator mediator, IDogService dogService, DogValidator dogValidator)
        {
            _mediator = mediator;
            _dogService = dogService;
            _dogValidator = dogValidator;
        }

        [HttpGet("GetDogById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetDogById(Guid id)
        {
            var dog = await _dogService.GetDogByIdAsync(id);
            if (dog == null) return NotFound();
            return Ok(dog);
        }

        [HttpGet("GetAllDogs")]
        [Authorize]
        public async Task<IActionResult> GetAllDogs()
        {
            var dogs = await _dogService.GetAllDogsAsync();
            return Ok(dogs);
        }

        [HttpPost("CreateDog")]
        [Authorize]
        public async Task<IActionResult> CreateDog([FromBody] AnimalDto dogDto)
        {
            var validationResult = _dogValidator.Validate(dogDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var newDog = await _dogService.CreateDogAsync(dogDto);
            return CreatedAtAction(nameof(GetDogById), new { id = newDog.AnimalID }, newDog);
        }

        [HttpGet("SearchDogs")]
        [Authorize]
        public async Task<IActionResult> GetDogsByBreedWeightColor([FromQuery] string breed, [FromQuery] int? weight, [FromQuery] string color)
        {
            var query = new GetDogsByBreedWeightColorQuery
            {
                Breed = breed,
                Weight = weight,
                Color = color
            };

            var dogs = await _mediator.Send(query);
            if (dogs == null || !dogs.Any())
            {
                return NotFound("No dogs found matching the criteria.");
            }

            return Ok(dogs);
        }

        [HttpPut("UpdateDog/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateDog(Guid id, [FromBody] AnimalDto dogDto)
        {
            try
            {
                await _dogService.UpdateDogAsync(id, dogDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteDog/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteDog(Guid id)
        {
            try
            {
                await _dogService.DeleteDogAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
