using backend.Entities;
using Microsoft.EntityFrameworkCore;


namespace backend
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<BookEntity> Books { get; set; } = null!;
        public DbSet<TopicEntity> Topics { get; set; } = null!;
        public DbSet<CategoryEntity> Categories { get; set; } = null!;
    }
}
