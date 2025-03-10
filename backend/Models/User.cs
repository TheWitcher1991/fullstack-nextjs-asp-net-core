using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class User
    {
        private User(Guid id, string email, string phone, string firstName, string lastName, string password)
        {
            Id = id;
            Email = email;
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; }
        [EmailAddress]
        public string Email { get; } = string.Empty;
        public string Phone { get; } = string.Empty;
        public string FirstName { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public DateTime CreatedAt { get; }

        public static User Create(Guid id, string email, string phone, string firstName, string lastName, string password)
        {
            return new User(id, email, phone, firstName, lastName, password);
        }
    }
}
