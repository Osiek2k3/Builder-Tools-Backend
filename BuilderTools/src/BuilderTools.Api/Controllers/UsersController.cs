using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Services;
using BuilderTools.Core.UseCase.UserCase;
using Microsoft.AspNetCore.Authorization;
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
        [ProducesResponseType(typeof(SignUpDto),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SignUpClient([FromForm] SignUpDto signUpClientDto,
            [FromServices] SignUpUseCase _signUpClientUseCase)
        {
            if (signUpClientDto.Role != "user" && signUpClientDto.Role != "admin")
            {
                return BadRequest(new { code = "BadRequest", reason = "Invalid role. Role must be either 'user' or 'admin'." });
            }

            await _signUpClientUseCase.ExecuteAsync(signUpClientDto.ToModel());
            return Ok();
        }

        //[HttpPost("registerCompany")]
        //[ProducesResponseType(typeof(SignUpDto), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> SignUpCompany([FromForm] SignUpCompanyDto signUpCompanyDto,
        //    [FromServices] SignUpCompanyUseCase _signUpCompanyUseCase)
        //{
        //    await _signUpCompanyUseCase.ExecuteAsync(signUpCompanyDto.ToModel());
        //    return Ok();
        //}

        [HttpPost("signin")]
        [ProducesResponseType(typeof(JwtDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JwtDto>> SignIn(
            [FromBody] SignInDto signInDto,
            [FromServices] SignInUseCase signInUseCase)
        {

            var user = await signInUseCase.ExecuteAsync(signInDto);
            var jwt = _tokenStorage.Get();
            return jwt;
        }

        [HttpGet("getAll")]
        [Authorize(Policy = "is-admin")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll(
            [FromServices] GetAllUsers _getAllUsers)
        {
            var users = await _getAllUsers.ExecuteAsync();

            return Ok(users);
        }
    }
}
