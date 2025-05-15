using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;
using BuilderTools.Core.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace BuilderTools.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ITokenStorage _tokenStorage;

        public UsersController(ITokenStorage tokenStorage)
        {
            _tokenStorage = tokenStorage;
        }

        [HttpPost("registerClient")]
        [ProducesResponseType(typeof(SignUpClientDto),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SignUpClient([FromForm] SignUpClientDto signUpClientDto,
            [FromServices] SignUpClientUseCase _signUpClientUseCase)
        {
            await _signUpClientUseCase.ExecuteAsync(signUpClientDto.ToModel());
            return Ok();
        }

        [HttpPost("registerCompany")]
        [ProducesResponseType(typeof(SignUpClientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SignUpCompany([FromForm] SignUpCompanyDto signUpCompanyDto,
            [FromServices] SignUpCompanyUseCase _signUpCompanyUseCase)
        {
            await _signUpCompanyUseCase.ExecuteAsync(signUpCompanyDto.ToModel());
            return Ok();
        }
    }
}
