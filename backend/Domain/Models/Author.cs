namespace backend.Domain.Models
{
    public class Author
    {
        private Author(Guid id, string fullName, string about,string avatarPath)
        {
            Id = id;
            FullName = fullName;
            About = about;
            AvatarPath = avatarPath;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public string FullName { get; } = string.Empty;
        public string About { get; } = string.Empty;
        public string AvatarPath { get; } = string.Empty;
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public virtual List<Book> Books { get; } = new List<Book>();

        public static Author Create(Guid id, string fullName, string about, string avatarPath)
        {
            return new Author(id, fullName, about, avatarPath);
        }
    }
}
