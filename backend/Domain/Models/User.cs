using backend.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Domain.Models
{
    public class User
    {
        private User(Guid id, string email, string phone, string firstName, string lastName, string password, Role role)
        {
            Id = id;
            Email = email;
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Role = role;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }
        [EmailAddress]
        public string Email { get; } = string.Empty;
        public string Phone { get; } = string.Empty;
        public Role Role { get; } = Role.User;
        public string FirstName { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public string Password { get; } = string.Empty;
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public virtual List<Book> Books { get; } = new List<Book>();
        public virtual List<Favorite> Favorites { get; } = new List<Favorite>();
        public virtual List<Impression> Impressions { get; } = new List<Impression>();

        public static User Create(Guid id, string email, string phone, string firstName, string lastName, string password, Role role)
        {
            return new User(id, email, phone, firstName, lastName, password, role);
        }
    }
}
