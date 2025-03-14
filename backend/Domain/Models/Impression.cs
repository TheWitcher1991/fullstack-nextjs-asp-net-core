namespace backend.Domain.Models
{
    public class Impression
    {
        private Impression(
            Guid id,
            string text,
            User user,
            Book book,
            List<Emotion> emotions
        )
        {
            Id = id;
            Text = text;
            User = user;
            Book = book;
            Emotions = emotions;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public string Text { get; } = string.Empty;
        public Guid UserId { get; }
        public Guid BookId { get; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public virtual User User { get; }
        public virtual Book Book { get; }
        public virtual List<Emotion> Emotions { get; } = new List<Emotion>();

        public static Impression Create(
            Guid id,
            string text,
            User user,
            Book book,
            List<Emotion> emotions
        )
        {
            return new Impression(id, text, user, book, emotions);
        }
    }
}
