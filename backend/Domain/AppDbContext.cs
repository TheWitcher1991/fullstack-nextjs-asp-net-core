using backend.Domain.Configurations;
using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Domain
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
        public DbSet<EmotionEntity> Emotions { get; set; } = null!;
        public DbSet<AuthorEntity> Authors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FavoriteConfiguration());
            modelBuilder.ApplyConfiguration(new ImpressionConfiguration());
            modelBuilder.ApplyConfiguration(new EmotionConfiguration());

            modelBuilder.Entity<TopicEntity>().HasData(DbInitializer.TopicsData());
            modelBuilder.Entity<CategoryEntity>().HasData(DbInitializer.CategoriesData());
            modelBuilder.Entity<EmotionEntity>().HasData(DbInitializer.EmotionsData());
            modelBuilder.Entity<UserEntity>().HasData(DbInitializer.UsersData());
            modelBuilder.Entity<AuthorEntity>().HasData(DbInitializer.AuthorsData());
            modelBuilder.Entity<BookEntity>().HasData(DbInitializer.BooksData());
            modelBuilder.Entity<ImpressionEntity>().HasData(DbInitializer.ImpressionsData());

            base.OnModelCreating(modelBuilder);
        }
    }
}
