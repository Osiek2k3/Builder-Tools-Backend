using BuilderTools.Core.DTO;

namespace BuilderTools.Core.Services
{
    public interface ITokenStorage
    {
        void Set(JwtDto jwt);
        JwtDto Get();
    }
}
