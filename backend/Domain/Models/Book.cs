using System.ComponentModel.DataAnnotations;

namespace backend.Domain.Models
{
    public class Book
    {

        private Book(
            Guid id,
            string imagePath,
            string filePath,
            string title,
            string description,
            string publisher,
            int age,
            int pages,
            User user,
            Author author,
            List<Category> categories,
            string? holder,
            string? translator
        )
        {
            Id = id;
            ImagePath = imagePath;
            FilePath = filePath;
            Title = title;
            Description = description;
            User = user;
            Author = author;
            Categories = categories;
            Holder = holder;
            Translator = translator;
            Publisher = publisher;
            Age = age;
            Pages = pages;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public string ImagePath { get; } = string.Empty;
        public string FilePath { get; } = string.Empty;
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public string Publisher { get; } = string.Empty;
        public string? Holder { get; }
        public string? Translator { get; }
        [Range(0, 120)]
        public int Age { get; }
        [Range(1, int.MaxValue)]
        public int Pages { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public Guid UserId { get; }
        public Guid AuthorId { get; }
        public virtual User User { get; }
        public virtual Author Author { get; }
        public virtual List<Category> Categories { get; } = new List<Category>();
        public virtual List<Impression> Impressions { get; } = new List<Impression>();
        // public virtual List<BookCategory> BookCategories { get; } = new List<BookCategory>();

        public static Book Create(
            Guid id,
            string imagePath,
            string filePath,
            string title,
            string description,
            string publisher,
            int age,
            int pages,
            User user,
            Author author,
            List<Category> categories,
            string? holder,
            string? translator
        )
        {
            return new Book(
                id,
                imagePath,
                filePath,
                title,
                description,
                publisher,
                age,
                pages,
                user,
                author,
                categories,
                holder,
                translator);
        }
    }
}
