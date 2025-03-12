namespace backend.Entities
{
    public class EmotionEntity
    {
        public Guid Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Unicode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual List<ImpressionEntity> Impressions { get; set; } = new List<ImpressionEntity>();
    }
}
