using backend.Models;

namespace backend.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; }

        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public Category Category { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
