using BuilderTools.Core.DTO;

namespace BuilderTools.Core.Services
{
    public interface IAuthenticator
    {
        Task<JwtDto> CreateToken(Guid userId, string role);
    }
}
