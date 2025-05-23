using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuilderTools.Core.DTO;
using BuilderTools.Core.Model;
using BuilderTools.Core.Services;
using BuilderTools.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuilderTools.Infrastructure.Auth
{
    public sealed class Authenticator : IAuthenticator
    {
        private readonly IClock _clock;
        private readonly string _issuer;
        private readonly TimeSpan _expiry;
        private readonly string _audience;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtSecurityTokenHandler _jwtSecurityToken = new JwtSecurityTokenHandler();
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public Authenticator(IOptions<AuthOptions> options, IClock clock,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _clock = clock;
            _issuer = options.Value.Issuer;
            _audience = options.Value.Audience;
            _expiry = options.Value.Expiry ?? TimeSpan.FromHours(1);
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(options.Value.SigningKey)),
                    SecurityAlgorithms.HmacSha256);
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<JwtDto> CreateToken(Guid userId, string role)
        {
            var now = _clock.Current();
            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new(ClaimTypes.Role, role)
        };

            var expires = now.Add(_expiry);
            var jwt = new JwtSecurityToken(_issuer, _audience, claims, now, expires, _signingCredentials);
            var token = _jwtSecurityToken.WriteToken(jwt);

            var refreshToken = new RefreshToken
            {
                UserId = userId,
                Token = Guid.NewGuid().ToString("N"),
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };

            await _refreshTokenRepository.AddAsync(refreshToken);

            return new JwtDto
            {
                UserId = userId,
                AccessToken = token,
                RefreshToken = refreshToken.Token
            };
        }
    }
}
