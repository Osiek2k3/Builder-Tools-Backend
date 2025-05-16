
namespace BuilderTools.Core.DTO
{
    public class SignUpCompanyDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NIP { get; set; }
        public string KRS { get; set; }
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public UserDto ToModel()
        {
            var UserDto = new UserDto(
                Guid.NewGuid(), FirstName, LastName, Address, Email, PhoneNumber, NIP, KRS, CompanyName, "Admin", Password);

            return UserDto;
        }
    }
}
