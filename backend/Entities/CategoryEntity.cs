using backend.Models;

namespace backend.Entities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; }
        public List<Book> Books { get; set; } = new();
    }
}
