namespace backend.Domain.Entities
{
    public class AuthorEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
        public string AvatarPath { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set;  } = DateTime.UtcNow;
        public virtual List<BookEntity> Books { get; set; } = new List<BookEntity>();
    }
}
