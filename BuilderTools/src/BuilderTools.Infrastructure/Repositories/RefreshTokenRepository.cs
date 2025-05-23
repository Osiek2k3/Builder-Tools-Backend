using BuilderTools.Core.Model;
using BuilderTools.Core.Services;
using BuilderTools.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly MyDbContext _dbContext;

        public RefreshTokenRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(RefreshToken token)
        {
            await _dbContext.RefreshTokens.AddAsync(token);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _dbContext.RefreshTokens
                .AsNoTracking()
                .FirstOrDefaultAsync(rt => rt.Token == token);
        }

        public async Task RevokeAsync(string token)
        {
            var existingToken = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.Token == token);

            if (existingToken != null)
            {
                existingToken.Revoked = true;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
