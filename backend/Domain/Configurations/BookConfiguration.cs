using backend.Domain.Entities;
using backend.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Domain.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(Config.MAX_TITLE_LENGTH);

            builder.Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(Config.MAX_DESCRIPTION_LENGTH);

            builder.Property(b => b.Publisher)
                .IsRequired()
                .HasMaxLength(Config.MAX_TITLE_LENGTH);

            builder.Property(b => b.Holder)
                .HasMaxLength(Config.MAX_TITLE_LENGTH);

            builder.Property(b => b.Translator)
                .HasMaxLength(Config.MAX_TITLE_LENGTH);

            // builder.ToTable(b => b.HasCheckConstraint("CK_Book_Age", "Age > 0 AND Age < 120"));

            // builder.ToTable(b => b.HasCheckConstraint("CK_Book_Pages", $"Pages >= 1 AND Pages <= {int.MaxValue}"));

            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasMany(b => b.Categories)
                .WithMany(c => c.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookCategory",
                    j => j.HasOne<CategoryEntity>()
                          .WithMany()
                          .HasForeignKey("CategoryId"),
                    j => j.HasOne<BookEntity>()
                          .WithMany()
                          .HasForeignKey("BookId"),
                    j =>
                    {
                        j.HasKey("BookId", "CategoryId");
                    }
                );

            builder.HasOne(b => b.User)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(b => b.Title);
            builder.HasIndex(b => b.UserId);
            builder.HasIndex(b => b.AuthorId);
        }
    }
}
