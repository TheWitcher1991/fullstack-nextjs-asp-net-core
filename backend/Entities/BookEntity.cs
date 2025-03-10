namespace backend.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; }
        public Guid TopicId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public virtual TopicEntity Topic { get; set; } = null!;
        public virtual CategoryEntity Category { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;
    }
}
