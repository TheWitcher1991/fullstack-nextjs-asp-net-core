﻿namespace backend.Domain.Models
{
    public class Category
    {
        private Category(Guid id, string title, Topic topic)
        {
            Id = id;
            Title = title;
            Topic = topic;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public Guid TopicId { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public virtual Topic Topic { get; }
        public virtual List<Book> Books { get; } = new List<Book>();
        // public virtual List<BookCategory> BookCategories { get; } = new List<BookCategory>();

        public static Category Create(Guid id, string title, Topic topic)
        {
            return new Category(id, title, topic);
        }
    }
}
