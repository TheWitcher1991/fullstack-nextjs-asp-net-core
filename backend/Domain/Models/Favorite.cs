namespace backend.Domain.Models
{
    public class Favorite
    {
        private Favorite(Guid id, Book book, User user)
        {
            Id = id;
            Book = book;
            User = user;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; }
        public Guid BookId { get; }
        public Guid UserId { get; }
        public DateTime CreatedAt { get; }
        public virtual Book Book { get; }
        public virtual User User { get; }

        public static Favorite Create(Guid id, Book book, User user)
        {
            return new Favorite(id, book, user);
        }
    }
}
