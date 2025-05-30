﻿using BuilderTools.Core.Model;
using BuilderTools.Core.Model.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace BuilderTools.Core.DTO
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }

        public UserDto(Guid id, string firstName, string lastName,string email, string phoneNumber,
                   string role, string password)
        {
            UserId = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
            Password = password;
        }

        //public UserDto(Guid id, string firstName, string lastName, string address,
        //               string email, string phoneNumber, string? nip, string? krs,
        //               string? companyName, string role, string password)
        //{
        //    UserId = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Permission = false;
        //    Address = address;
        //    Email = email;
        //    PhoneNumber = phoneNumber;
        //    NIP = nip;
        //    KRS = krs;
        //    CompanyName = companyName;
        //    Role = role;
        //    Password = password;
        //}

        public User ToModel()
        {
            return new User(UserId, FirstName, LastName, Email,
                PhoneNumber, Role, Password);
        }
    }
}
