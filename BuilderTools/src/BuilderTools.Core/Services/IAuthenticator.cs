using BuilderTools.Core.DTO;

namespace BuilderTools.Core.Services
{
    public interface IAuthenticator
    {
        JwtDto CreateToken(Guid userId, string role);
    }
}
