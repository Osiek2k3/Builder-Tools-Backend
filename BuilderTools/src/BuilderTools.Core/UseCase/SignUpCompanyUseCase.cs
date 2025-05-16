using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase
{
    public class SignUpCompanyUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;

        public SignUpCompanyUseCase(IUserRepository userRepository, IPasswordManager passwordManager)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
        }

        public async Task ExecuteAsync(UserDto userDto)
        {
            var user = await _userRepository.IsEmailTakenAsync(userDto.Email);
            if (user == true)
            {
                throw new InvalidCredentialsException("Ten Email jest zajety");
            }

            userDto.Haslo = _passwordManager.Secure(userDto.Haslo);
            await _userRepository.AddAsync(userDto.ToModel());
        }
    }
}
