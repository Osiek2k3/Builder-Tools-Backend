using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Model.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BuilderTools.Core.DTO
{
    public class SignUpDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Permission { get; set; }
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public UserDto ToModel()
        {
            if (Role == "user")
            {
                var UserDto = new UserDto(
                Guid.NewGuid(), FirstName, LastName, Permission, Address, Email, PhoneNumber,
                new Role("user"), Password);
                return UserDto;
            }
            else 
            {
                var UserDto = new UserDto(
                Guid.NewGuid(), FirstName, LastName, Permission, Address, Email, PhoneNumber,
                new Role("admin"), Password);
                return UserDto;
            }
        }
    }
}
