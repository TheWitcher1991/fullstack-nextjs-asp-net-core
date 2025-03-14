namespace backend.Domain.Models
{
    public class Emotion
    {
        private Emotion(Guid id, string label, string name, string unicode)
        {
            Id = id;
            Label = label;
            Name = name;
            Unicode = unicode;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public string Label { get; } = string.Empty;
        public string Name { get; } = string.Empty;
        public string Unicode { get; } = string.Empty;
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public virtual List<Impression> Impressions { get; } = new List<Impression>();

        public static Emotion Create(Guid id, string label, string name, string unicode)
        {
            return new Emotion(id, label, name, unicode);
        }
    }
}
