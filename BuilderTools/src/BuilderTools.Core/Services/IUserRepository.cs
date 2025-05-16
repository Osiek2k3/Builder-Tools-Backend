
using BuilderTools.Core.DTO;
using BuilderTools.Core.Model;

namespace BuilderTools.Core.Services
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
