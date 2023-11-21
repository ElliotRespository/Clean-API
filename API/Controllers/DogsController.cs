﻿using Application.Commands.Dogs.CreateDog;
using Application.Commands.Dogs.UpdateDog;
using Application.Querys.Dogs.GetAllDogs;
using Application.Querys.Dogs.GetDogById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
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
        [Route ("getAllDogs")]
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

        // POST api/v1/dogs
        [HttpPost]
        public async Task<IActionResult> CreateDog([FromBody] CreateDogCommand command)
        {
            var dog = await _mediatR.Send(command);
            return CreatedAtAction(nameof(GetDogById), new {dogid = dog.animalID}, dog);
        }

        // PUT api/v1/dogs/{dogid}
        [HttpPut("{dogid}")]
        public async Task<IActionResult> Put(Guid dogid, [FromBody] UpdateDogCommander command)
        {
            if(dogid != command.AnimalID)
            {
                return BadRequest("fel dogid i rutan och body");
            }

            var updatedDog = await _mediatR.Send(command);
            if(updatedDog == null)
            {
                return NotFound();  
            }

            return Ok(updatedDog);
        }
    }
}
