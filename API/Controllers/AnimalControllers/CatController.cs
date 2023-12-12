using Application.Commands.Cats.CreateCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Commands.Dogs.CreateDog;
using Application.Dtos;
using Application.Querys.Cats.GetAllCats;
using Application.Querys.Cats.GetCatById;
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
        internal readonly IMediator _mediatR;
        internal readonly CatValidator _catValidator;

        public CatController(IMediator mediatR, CatValidator catValidator)
        {
            _mediatR = mediatR;
            _catValidator = catValidator;

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
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateCat([FromBody] AnimalDto newCat)
        {
            //validate dog
            var validatedCat = _catValidator.Validate(newCat);
            //error handling
            if (!validatedCat.IsValid)
            {
                return BadRequest(validatedCat.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _mediatR.Send(new CreateDogCommand(newCat)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


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
