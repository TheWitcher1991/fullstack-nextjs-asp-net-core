namespace backend.Entities
{
    public class TopicEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public virtual List<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();
    }
}
