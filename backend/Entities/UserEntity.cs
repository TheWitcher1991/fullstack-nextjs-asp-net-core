using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; }
        public List<BookEntity> Books { get; set; } = new();
    }
}
