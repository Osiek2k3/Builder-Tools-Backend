using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Model;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase
{
    public class GetAllUsers
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsers(IUserRepository userRepository)
        {
            _userRepository = userRepository;;
        }

        public async Task<IEnumerable<User>> ExecuteAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users;
        }
    }
}
