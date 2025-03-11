using backend.Configurations;
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
        public DbSet<FavoriteEntity> Favorites { get; set; } = null!;
        public DbSet<ImpressionEntity> Impressions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FavoriteConfiguration());
            modelBuilder.ApplyConfiguration(new ImpressionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
