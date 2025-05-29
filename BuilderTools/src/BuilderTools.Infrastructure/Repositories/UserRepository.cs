using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Model;
using BuilderTools.Core.Services;
using BuilderTools.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;

        public UserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(User user)
        {
            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas pobierania braków produktów.", ex);
            }
        }

        public async Task UpdateAsync(User user)
        {
            try
            {
                var existingUser = await _dbContext.Users.FindAsync(user.UserId);
                if (existingUser == null)
                {
                    throw new NotFoundException($"Użytkownik o ID '{user.UserId}' nie został znaleziony.");
                }

                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.Role = user.Role;
                existingUser.Password = user.Password;

                _dbContext.Users.Update(existingUser);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas edytowania użytkownika w bazie danych.", ex);
            }
        }


        public async Task<bool> IsEmailTakenAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.Email == email);

                return user;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas próby logowania.", ex);
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas pobierania użytkowników.", ex);
            }
        }

        public async Task<bool> CheckIdUserAsync(Guid userId)
        {
            return await _dbContext.Users
                .AnyAsync(x => x.UserId == userId);
        }
    }
}
