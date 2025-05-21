using BuilderTools.Core.DTO;
using BuilderTools.Core.UseCase.RentalCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuilderTools.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        [HttpPost("AddRental")]
        [Authorize(Policy = "is-admin")]
        [ProducesResponseType(typeof(RentalInputDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddCategory([FromForm] RentalInputDto rentalInputDto,
            [FromServices] AddRentalUseCase addRentalUseCase)
        {
            await addRentalUseCase.ExecuteAsync(rentalInputDto);
            return Ok();
        }

        [HttpPut("EditRental")]
        [Authorize(Policy = "is-admin")]
        [ProducesResponseType(typeof(RentalDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditCategory([FromForm] RentalDto rentalDto,
            [FromServices] EditRentalUseCase editRentalUseCase)
        {
            await editRentalUseCase.ExecuteAsync(rentalDto);
            return Ok();
        }

        [HttpGet("GetById")]
        [ProducesResponseType(typeof(RentalDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDto>> GetById([FromQuery] Guid builderToolId,
            [FromServices] GetByIdRentalUseCase getByIdRentalUseCase)
        {
            var rental = await getByIdRentalUseCase.ExecuteAsync(builderToolId);
            return Ok(rental);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(RentalDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RentalDto>>> GetAll(
            [FromServices] GetAllRentalUseCase getAllRentalUseCase)
        {
            var rental = await getAllRentalUseCase.ExecuteAsync();
            return Ok(rental);
        }
    }
}
