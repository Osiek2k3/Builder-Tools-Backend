using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.UserCase
{
    public class SignUpUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordManager _passwordManager;

        public SignUpUseCase(IUserRepository userRepository, IPasswordManager passwordManager)
        {
            _userRepository = userRepository;
            _passwordManager = passwordManager;
        }

        public async Task ExecuteAsync(UserDto userDto)
        {
            if (userDto == null)
            {
                throw new InvalidException("Invalid role. Role must be either 'user' or 'admin'.");
            }

            var user = await _userRepository.IsEmailTakenAsync(userDto.Email);
            if (user == true)
            {
                throw new InvalidException("Ten Email jest zajety");
            }

            userDto.Password = _passwordManager.Secure(userDto.Password);
            await _userRepository.AddAsync(userDto.ToModel());
        }
    }
}
