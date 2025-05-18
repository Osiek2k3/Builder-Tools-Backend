using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Model;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.UserCase
{
    public class SignInUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticator _authenticator;
        private readonly IPasswordManager _passwordManager;
        private readonly ITokenStorage _tokenStorage;

        public SignInUseCase(IUserRepository userRepository, IAuthenticator authenticator, IPasswordManager passwordManager, ITokenStorage tokenStorage)
        {
            _userRepository = userRepository;
            _authenticator = authenticator;
            _passwordManager = passwordManager;
            _tokenStorage = tokenStorage;
        }

        public async Task<User> ExecuteAsync(SignInDto SignInDto)
        {
            var user = await _userRepository.IsEmailTakenAsync(SignInDto.Email);
            if(user == false)
            {
                throw new InvalidCredentialsException("Nie ma użytkownika o takim emailu");
            }
            var userParm = await _userRepository.GetByEmailAsync(SignInDto.Email);
            if (!_passwordManager.Validate(SignInDto.Password, userParm.Password))
            {
                throw new InvalidCredentialsException("Blędne haslo");
            }

            var jwt = _authenticator.CreateToken(userParm.UserId, userParm.Role);
            _tokenStorage.Set(jwt);

            return userParm;
        }
    }
}
