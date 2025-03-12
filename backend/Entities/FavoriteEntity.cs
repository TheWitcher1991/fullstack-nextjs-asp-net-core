namespace backend.Entities
{
    public class FavoriteEntity
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual BookEntity Book { get; set; } = null!;
        public virtual UserEntity User { get; set; } = null!;
    }
}
