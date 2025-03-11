using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity> 
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title).IsRequired().HasMaxLength(Config.MAX_TITLE_LENGTH);

            builder.Property(b => b.Description).IsRequired().HasMaxLength(Config.MAX_DESCRIPTION_LENGTH);

            builder.HasMany(b => b.Categories)
                .WithMany(c => c.Books);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
