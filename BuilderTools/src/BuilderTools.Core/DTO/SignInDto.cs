using System.ComponentModel.DataAnnotations;

namespace BuilderTools.Core.DTO
{
    public class SignInDto
    {
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
