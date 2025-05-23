using BuilderTools.Core.Model;

namespace BuilderTools.Core.Services
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken token);
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task RevokeAsync(string token);
    }
}
