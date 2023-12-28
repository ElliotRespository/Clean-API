using Application.Commands.Cats.CreateCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Commands.Dogs.CreateDog;
using Application.Dtos.Animal;
using Application.Querys.Cats.GetAllCats;
using Application.Querys.Cats.GetCatByBreedWeightColor;
using Application.Querys.Cats.GetCatById;
using Application.Services.Animals.Dogs_Cats;
using Application.Validators.Cat;
using Application.Validators.Dog;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.AnimalControllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICatService _catService;
        private readonly CatValidator _catValidator;

        public CatController(IMediator mediator, ICatService catService, CatValidator catValidator)
        {
            _mediator = mediator;
            _catService = catService;
            _catValidator = catValidator;
        }

        [HttpGet("GetCatById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetCatById(Guid id)
        {
            var cat = await _catService.GetCatByIdAsync(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }

        [HttpGet("GetAllCats")]
        [Authorize]
        public async Task<IActionResult> GetAllCats()
        {
            var cats = await _catService.GetAllCatsAsync();
            return Ok(cats);
        }

        [HttpPost("CreateCat")]
        [Authorize]
        public async Task<IActionResult> CreateCat([FromBody] AnimalDto catDto)
        {
            var validationResult = _catValidator.Validate(catDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var newCat = await _catService.CreateCatAsync(catDto);
            return CreatedAtAction(nameof(GetCatById), new { id = newCat.AnimalID }, newCat);
        }

        [HttpGet("SearchCats")]
        [Authorize]
        public async Task<IActionResult> GetCatsByBreedWeightColor([FromQuery] string breed, [FromQuery] int? weight, [FromQuery] string color)
        {
            var query = new GetCatsByBreedWeightColorQuery
            {
                Breed = breed,
                Weight = weight,
                Color = color
            };

            var cats = await _mediator.Send(query);
            if (cats == null || !cats.Any())
            {
                return NotFound("No cats found matching the criteria.");
            }

            return Ok(cats);
        }

        [HttpPut("UpdateCat/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateCat(Guid id, [FromBody] AnimalDto catDto)
        {
            try
            {
                await _catService.UpdateCatAsync(id, catDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteCat/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCat(Guid id)
        {
            try
            {
                await _catService.DeleteCatAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
