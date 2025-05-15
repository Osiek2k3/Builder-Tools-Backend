using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase
{
    public class SignUpCompanyUseCase
    {
        private readonly IUserRepository _userRepository;

        public SignUpCompanyUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(UserDto userDto)
        {
            await _userRepository.AddAsync(userDto.ToModel());
        }
    }
}
