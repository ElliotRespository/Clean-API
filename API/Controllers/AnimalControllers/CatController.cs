using Application.Commands.Cats.CreateCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Application.Querys.Cats.GetAllCats;
using Application.Querys.Cats.GetCatById;
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
        internal readonly IMediator _mediatR;

        public CatController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        //Detta är API endpoint där vi hämtar alla hundar från MockDatabase
        [HttpGet]
        [Route("getAllCats")]
        public async Task<IActionResult> GetAllCats()
        {

            return Ok(await _mediatR.Send(new GetAllCatsQuery()));
        }

        [HttpGet]
        [Route("getCatById/{catid}")]
        public async Task<IActionResult> GetCatById(Guid catid
            )
        {
            return Ok(await _mediatR.Send(new GetCatByIdQuery(catid)));
        }


        [HttpPost]
        [Route("createCat")]
        [Authorize]
        public async Task<IActionResult> CreateCat([FromBody] AnimalDto catDto)
        {
            var command = new CreateCatCommand { Cat = catDto };
            var cat = await _mediatR.Send(command);
            return CreatedAtAction(nameof(GetCatById), new { catid = cat.animalID }, cat);
        }

        [HttpPut]
        [Route("updateCat/{updatedCatId}")]
        public async Task<IActionResult> UpdateCat([FromBody] AnimalDto updatedCat, Guid updatedCatId)
        {
            var command = new UpdateCatByIdCommand(updatedCat, updatedCatId);
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
        [Route("deleteCat/{catid}")]
        public async Task<IActionResult> Delete(Guid catid)
        {
            var command = new DeleteCatByIdCommand(catid);
            var result = await _mediatR.Send(command);
            if (result != null)
            {
                return Ok(result);
            }
            else { return NotFound(); }
        }
    }
}
