using Application.Commands.Dogs.CreateDog;
using Application.Commands.Dogs.DeleteDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos.Dogdto;
using Application.Querys.Dogs.GetAllDogs;
using Application.Querys.Dogs.GetDogById;
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

        public DogsController(IMediator mediatR)
        {
            _mediatR = mediatR;
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
        public async Task<IActionResult> CreateDog([FromBody] DogDto dogDto)
        {
            var command = new CreateDogCommand { Dog = dogDto };
            var dog = await _mediatR.Send(command);
            return CreatedAtAction(nameof(GetDogById), new { dogid = dog.animalID }, dog);
        }

        [HttpPut]
        [Route("updateDog/{updatedDogId}")]
        public async Task<IActionResult> UpdateDog([FromBody] DogDto updatedDog, Guid updatedDogId)
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
