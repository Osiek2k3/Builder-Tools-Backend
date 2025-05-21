using BuilderTools.Core.DTO;
using BuilderTools.Core.UseCase.BuilderToolCase;
using BuilderTools.Core.UseCase.CategoryCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuilderTools.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuilderToolController : ControllerBase
    {
        [HttpPost("AddBuildertool")]
        [Authorize(Policy = "is-admin")]
        [ProducesResponseType(typeof(BuilderToolInputDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddCategory([FromForm] BuilderToolInputDto builderToolInputDto,
            [FromServices] AddBuilderToolUseCase addBuilderToolUseCase)
        {
            await addBuilderToolUseCase.ExecuteAsync(builderToolInputDto);
            return Ok();
        }

        [HttpPut("EditBuildertool")]
        [Authorize(Policy = "is-admin")]
        [ProducesResponseType(typeof(BuilderToolDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditCategory([FromForm] BuilderToolDto builderToolDto,
            [FromServices] EditBuilderToolUseCase editBuilderToolUseCase)
        {
            await editBuilderToolUseCase.ExecuteAsync(builderToolDto);
            return Ok();
        }

        [HttpGet("GetById")]
        [ProducesResponseType(typeof(BuilderToolDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoryDto>> GetById([FromQuery] Guid builderToolId,
            [FromServices] GetByIdBuilderToolUseCase getByIdBuilderToolUseCase)
        {
            var category = await getByIdBuilderToolUseCase.ExecuteAsync(builderToolId);
            return Ok(category);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(BuilderToolDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<BuilderToolDto>>> GetAll(
            [FromServices] GetAllBuilderToolUseCase getAllBuilderToolUseCase)
        {
            var builderTools = await getAllBuilderToolUseCase.ExecuteAsync();
            //var zm = builderTools.First();
            //return File(zm.Image, "image/jpeg");
            return Ok(builderTools);
        }

    }
}
