namespace backend.Models
{
    public class Category
    {
        private Category(Guid id, string title, Topic topic)
        {
            Id = id;
            Title = title;
            Topic = topic;
            CreatedAt = DateTime.Now;
        }
 
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public Guid TopicId { get; }
        public DateTime CreatedAt { get; }
        public virtual Topic Topic { get; }
        public virtual List<Book> Books { get; } = new List<Book>();

        public static Category Create(Guid id, string title, Topic topic)
        {
            return new Category(id, title, topic);
        }
    }
}
