namespace backend.Domain.Entities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Guid TopicId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual TopicEntity Topic { get; set; } = null!;
        public virtual List<BookEntity> Books { get; set; } = new List<BookEntity>();
    }
}
