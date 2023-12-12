using Application.Commands.Dogs.CreateDog;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Application.Querys.Dogs.GetAllDogs;
using Application.Querys.Dogs.GetDogById;
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
        internal readonly IMediator _mediatR;
        internal readonly DogValidator _dogValidator;


        public DogsController(IMediator mediatR, DogValidator dogValidator)
        {
            _mediatR = mediatR;
            _dogValidator = dogValidator;
        }
        //Detta är API endpoint där vi hämtar alla hundar från MockDatabase
        [HttpGet]
        [Route("getAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {

            return Ok(await _mediatR.Send(new GetAllDogsQuery()));
        }

        [HttpGet]
        [Route("getDogById/{dogid}")]
        public async Task<IActionResult> GetDogById(Guid dogid
            )
        {
            return Ok(await _mediatR.Send(new GetDogByIdQuery(dogid)));
        }


        [HttpPost]
        [Route("createDog")]
        [Authorize]
        public async Task<IActionResult> CreateDog([FromBody] AnimalDto newDog)
        {
            //validate dog
            var validatedDog = _dogValidator.Validate(newDog);
            //error handling
            if (!validatedDog.IsValid)
            {
                return BadRequest(validatedDog.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new CreateDogCommand(newDog)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] AnimalDto updatedDog, Guid updatedDogId)
        {
            var command = new UpdateDogByIdCommand(updatedDog, updatedDogId);
            var result = await _mediatR.Send(command);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("deleteDog/{dogid}")]
        public async Task<IActionResult> Delete(Guid dogid)
        {
            var command = new DeleteDogByIdCommand(dogid);
            var result = await _mediatR.Send(command);
            if (result != null)
            {
                return Ok(result);
            }
            else { return NotFound(); }
        }
    }
}
