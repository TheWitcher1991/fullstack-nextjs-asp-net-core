namespace backend.Models
{
    public class Topic
    {
        private Topic(Guid id, string title)
        {
            Id = id;
            Title = title;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public DateTime CreatedAt { get; }
        public virtual List<Category> Categories { get; } = new List<Category>();

        public static Topic Create(Guid id, string title)
        {
            return new Topic(id, title);
        }
    }
}