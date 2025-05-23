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

        public async Task<User> ExecuteAsync(SignInDto signInDto)
        {
            var userExists = await _userRepository.IsEmailTakenAsync(signInDto.Email);
            if (!userExists)
            {
                throw new InvalidException("Nie ma użytkownika o takim emailu");
            }

            var user = await _userRepository.GetByEmailAsync(signInDto.Email);
            if (!_passwordManager.Validate(signInDto.Password, user.Password))
            {
                throw new InvalidException("Błędne hasło");
            }

            var jwt = await _authenticator.CreateToken(user.UserId, user.Role);
            _tokenStorage.Set(jwt);

            return user;
        }

    }
}
