using System.Threading;
using BuilderTools.Core.DTO;
using BuilderTools.Core.UseCase.RentalCase;
using BuilderTools.Core.UseCase.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuilderTools.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        [HttpPost("AddRental")]
        [Authorize]
        [ProducesResponseType(typeof(RentalInputDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddCategory([FromForm] RentalInputDto rentalInputDto,
            [FromServices] AddRentalUseCase addRentalUseCase,
            [FromServices] RentalInputDtoValidator validationRules)
        {
            var validationResult = await validationRules.ValidateAsync(rentalInputDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            await addRentalUseCase.ExecuteAsync(rentalInputDto);
            return Ok();
        }

        [HttpPut("EditRental")]
        [Authorize]
        [ProducesResponseType(typeof(RentalDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditCategory([FromForm] RentalDto rentalDto,
            [FromServices] EditRentalUseCase editRentalUseCase,
            [FromServices] RentalValidator validationRules)
        {
            var validationResult = await validationRules.ValidateAsync(rentalDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            await editRentalUseCase.ExecuteAsync(rentalDto);
            return Ok();
        }

        [HttpGet("GetById")]
        [Authorize(Policy = "is-admin")]
        [ProducesResponseType(typeof(RentalDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDto>> GetById([FromQuery] Guid builderToolId,
            [FromServices] GetByIdRentalUseCase getByIdRentalUseCase)
        {
            var rental = await getByIdRentalUseCase.ExecuteAsync(builderToolId);
            return Ok(rental);
        }

        [HttpGet("GetAll")]
        [Authorize(Policy = "is-admin")]
        [ProducesResponseType(typeof(RentalDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RentalDto>>> GetAll(
            [FromServices] GetAllRentalUseCase getAllRentalUseCase)
        {
            var rental = await getAllRentalUseCase.ExecuteAsync();
            return Ok(rental);
        }

        [HttpGet("Active")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<RentalDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RentalDto>>> GetActiveRentals(
            [FromQuery] Guid userId, [FromServices] GetActiveRentalsUseCase useCase)
        {
            var rentals = await useCase.ExecuteAsync(userId);
            return Ok(rentals);
        }

        [HttpGet("Completed")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<RentalDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RentalDto>>> GetCompletedRentals(
            [FromQuery] Guid userId, [FromServices] GetCompletedRentalsUseCase useCase)
        {
            var rentals = await useCase.ExecuteAsync(userId);
            return Ok(rentals);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRental(Guid id, [FromServices] DeleteRentalUseCase useCase)
        {
            await useCase.ExecuteAsync(id);
            return NoContent();
        }

    }
}
