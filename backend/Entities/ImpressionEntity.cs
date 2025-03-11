using backend.Models;

namespace backend.Entities
{
    public class ImpressionEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsAdvise { get; set; }
        public bool IsNoAsdvise { get; set; }
        public bool IsToTearss { get; set; }
        public bool IsNice { get; set; }
        public bool IsBoring { get; set; }
        public bool IsScary { get; set; }
        public bool IsWisely { get; set; }
        public bool IsUnclear { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual UserEntity User { get; } = null!;
        public virtual BookEntity Book { get; } = null!;
    }
}
