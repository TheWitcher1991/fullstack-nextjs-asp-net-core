using backend.Models;

namespace backend.Entities
{
    public class ImpressionEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual UserEntity User { get; set;  } = null!;
        public virtual BookEntity Book { get; set; } = null!;
        public virtual List<EmotionEntity> Emotions { get; set; } = new List<EmotionEntity>();
    }
}
