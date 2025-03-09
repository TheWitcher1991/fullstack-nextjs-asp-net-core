using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class User
    {
        private User(string email, string phone, string firstName, string lastName, string password)
        {
            Email = email;
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

        public int Id { get; }
        [EmailAddress]
        public string Email { get; } = string.Empty;
        public string Phone { get; } = string.Empty;
        public string FirstName { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public List<Book> Books { get; } = new();

        public static (User User, string Error) Create(string email, string phone, string firstName, string lastName, string password)
        {
            var error = string.Empty;

            var user = new User(email, phone, firstName, lastName, password);

            return (user, error);
        }
    }
}
