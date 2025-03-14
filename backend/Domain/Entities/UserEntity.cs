using backend.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.User;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual List<BookEntity> Books { get; set; } = new List<BookEntity>();
        public virtual List<FavoriteEntity> Favorites { get; set; } = new List<FavoriteEntity>();
        public virtual List<ImpressionEntity> Impressions { get; set; } = new List<ImpressionEntity>();
    }
}
