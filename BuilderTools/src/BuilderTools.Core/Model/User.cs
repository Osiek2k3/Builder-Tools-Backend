
using BuilderTools.Core.Model.ValueObjects;

namespace BuilderTools.Core.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(Guid userId, string firstName, string lastName,
            string email, string phoneNumber, Role role, string password)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
            Password = password;
        }
    }
}
