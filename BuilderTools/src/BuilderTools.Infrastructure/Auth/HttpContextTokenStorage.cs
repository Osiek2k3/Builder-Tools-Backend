using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;
using Microsoft.AspNetCore.Http;

namespace BuilderTools.Infrastructure.Auth
{
    internal sealed class HttpContextTokenStorage : ITokenStorage
    {
        private const string TokenKey = "jwt";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextTokenStorage(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public JwtDto Get()
        {
            if (_httpContextAccessor.HttpContext == null)
            {
                return null;
            }

            if (_httpContextAccessor.HttpContext.Items.TryGetValue(TokenKey, out var jwt))
            {
                return jwt as JwtDto;
            }

            return null;
        }

        public void Set(JwtDto jwt)
            => _httpContextAccessor.HttpContext?.Items.TryAdd(TokenKey, jwt);
    }
}
