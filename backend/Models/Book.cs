namespace backend.Models
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
            List<Category> categories,
            string? holder,
            string? translator
        ) {
            Id = id;
            ImagePath = imagePath;
            FilePath = filePath;
            Title = title;
            Description = description;
            User = user;
            Categories = categories;
            Holder = holder;
            Translator = translator;
            Publisher = publisher;
            Age = age;
            Pages = pages;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; }
        public string ImagePath { get; } = string.Empty;
        public string FilePath { get; } = string.Empty;
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public string Publisher { get; } = string.Empty;
        public string? Holder { get; }
        public string? Translator { get; }
        public int Age { get; }
        public int Pages { get; }
        public DateTime CreatedAt { get; }
        public Guid UserId { get; }
        public virtual User User { get; }
        public virtual List<Category> Categories { get; } = new List<Category>();
        public virtual List<Impression> Impressions { get; } = new List<Impression>();

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
                categories,
                holder,
                translator);
        }
    }
}
