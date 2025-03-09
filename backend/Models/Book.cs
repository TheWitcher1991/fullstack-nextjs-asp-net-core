using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Book
    {

        private Book(string title, string description, decimal price, Category category, User user) {
            Title = title;
            Description = description;
            Price = price;
            Category= category;
            User = user;
        }

        public int Id { get; }

        public string Title { get; } = string.Empty;

        public string Description { get; } = string.Empty;

        public decimal Price { get; }

        public int CategoryId { get; }

        public int UserId { get; }

        public Category Category { get; }

        public User User { get; }

        public static (Book Book, string Error) Create(string title, string description, decimal price, Category category, User user)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > Config.MAX_TITLE_LENGTH) {
                error = $"Title can not be empty or longer then {Config.MAX_TITLE_LENGTH} symbols";
            }

            if (price < Config.MIN_PRICE)
            {
                error = $"Price can not be lonter {Config.MIN_PRICE} then";
            }

            var book = new Book(title, description, price, category, user);

            return (book, error);
        }
    }
}
