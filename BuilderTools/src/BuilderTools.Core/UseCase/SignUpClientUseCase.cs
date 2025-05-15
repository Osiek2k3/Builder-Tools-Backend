using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase
{
    public class SignUpClientUseCase
    {
        private readonly IUserRepository _userRepository;

        public SignUpClientUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(UserDto userDto)
        {
            await _userRepository.AddAsync(userDto.ToModel());
        }
    }
}
