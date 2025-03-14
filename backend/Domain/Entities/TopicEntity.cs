namespace backend.Domain.Entities
{
    public class TopicEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual List<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();
    }
}
