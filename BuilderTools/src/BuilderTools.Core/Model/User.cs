
using System.Net;

namespace BuilderTools.Core.Model
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Permission { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? NIP { get; set; }
        public string? KRS { get; set; }
        public string? CompanyName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(Guid userId, string firstName, string lastName, bool permission, string address,
            string email, string phoneNumber, string? nip, string? krs, string? companyName, string role, string password)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Permission = permission;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            NIP = nip;
            KRS = krs;
            CompanyName = companyName;
            Role = role;
            Password = password;
        }
    }
}
