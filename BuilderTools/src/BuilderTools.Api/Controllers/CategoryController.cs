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

        [HttpGet("GetById")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDto>> GetById([FromQuery] Guid categoryId,
            [FromServices] GetByIdCategoryUseCase _getByIdCategoryUseCase)
        {
            var category = await _getByIdCategoryUseCase.ExecuteAsync(categoryId);
            return Ok(category);
        }

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
