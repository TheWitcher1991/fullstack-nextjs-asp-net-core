using backend.Models;

namespace backend.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string? Holder { get; set; }
        public string? Translator { get; set; }
        public int Age { get; set; }
        public int Pages { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;
        public virtual List<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();
        public virtual List<ImpressionEntity> Impressions { get; set; } = new List<ImpressionEntity>();
    }
}
