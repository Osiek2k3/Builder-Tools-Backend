
using BuilderTools.Core.DTO;
using BuilderTools.Core.Model;

namespace BuilderTools.Core.Services
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
    }
}
