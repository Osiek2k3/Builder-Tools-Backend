
namespace BuilderTools.Core.DTO
{
    public class SignUpClientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Permission { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public UserDto ToModel()
        {
            var UserDto = new UserDto(
                Guid.NewGuid(), FirstName, LastName, Permission, Address, Email, PhoneNumber, "Admin", Password);

            return UserDto;
        }
    }
}
