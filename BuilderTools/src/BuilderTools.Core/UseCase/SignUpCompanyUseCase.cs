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

            userDto.Password = _passwordManager.Secure(userDto.Password);
            await _userRepository.AddAsync(userDto.ToModel());
        }
    }
}
