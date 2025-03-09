    using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Book
    {

        private Book(Guid id, string title, string description, decimal price, Category category, User user) {
            Title = title;
            Description = description;
            Price = price;
            Category= category;
            User = user;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; }

        public string Title { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public decimal Price { get; }
        public DateTime CreatedAt { get; }

        public Guid CategoryId { get; }

        public Guid UserId { get; }

        public Category Category { get; }

        public User User { get; }

        public static Book Create(Guid id, string title, string description, decimal price, Category category, User user)
        {
            return new Book(id, title, description, price, category, user);
        }
    }
}
