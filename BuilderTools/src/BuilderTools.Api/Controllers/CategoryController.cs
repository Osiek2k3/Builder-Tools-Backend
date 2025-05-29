using BuilderTools.Core.DTO;
using BuilderTools.Core.UseCase.CategoryCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuilderTools.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        /// <summary>
        /// Dodanie kategorii
        /// </summary>
        [HttpPost("AddCategory")]
        [Authorize(Policy = "is-admin")]
        [ProducesResponseType(typeof(CategoryInputDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddCategory([FromForm] CategoryInputDto categoryInputDto,
            [FromServices] AddCategoryUseCase _addCategoryUseCase)
        {
            await _addCategoryUseCase.ExecuteAsync(categoryInputDto);
            return Ok();
        }

        /// <summary>
        /// Edytowanie kategorii
        /// </summary>
        [HttpPut("EditCategory")]
        [Authorize(Policy = "is-admin")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditCategory([FromForm] CategoryDto categoryDto,
            [FromServices] EditCategoryUseCase _editCategoryUseCase)
        {
            await _editCategoryUseCase.ExecuteAsync(categoryDto);
            return Ok();
        }

        /// <summary>
        /// Usuwanie kategorii
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Policy = "is-admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategory(Guid id, [FromServices] DeleteCategoryUseCase useCase)
        {
            await useCase.ExecuteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Zwracanie jednej kategorii
        /// </summary>
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDto>> GetById([FromQuery] Guid categoryId,
            [FromServices] GetByIdCategoryUseCase _getByIdCategoryUseCase)
        {
            var category = await _getByIdCategoryUseCase.ExecuteAsync(categoryId);
            return Ok(category);
        }

        /// <summary>
        /// Zwracanie wszystkich kategorii
        /// </summary>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll(
            [FromServices] GetAllCategoryUseCase _getAllCategoryUseCase)
        {
            var category = await _getAllCategoryUseCase.ExecuteAsync();
            return Ok(category);
        }
    }
}
