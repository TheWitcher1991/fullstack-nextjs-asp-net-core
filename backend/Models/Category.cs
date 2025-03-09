namespace backend.Models
{
    public class Category
    {
        private Category(Guid id, string title)
        {
            Id = id;
            Title = title;
            CreatedAt = DateTime.Now;
        }
 
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public DateTime CreatedAt { get; }
        public List<Book> Books { get; } = new();

        public static Category Create(Guid id, string title)
        {
            return new Category(id, title);
        }
    }
}
