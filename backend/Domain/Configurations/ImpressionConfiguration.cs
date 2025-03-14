using backend.Domain.Entities;
using backend.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Domain.Configurations
{
    public class ImpressionConfiguration : IEntityTypeConfiguration<ImpressionEntity>
    {
        public void Configure(EntityTypeBuilder<ImpressionEntity> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Text)
                .IsRequired()
                .HasMaxLength(Config.MAX_DESCRIPTION_LENGTH);

            builder.Property(i => i.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(i => i.User)
                .WithMany(u => u.Impressions)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Book)
                .WithMany(b => b.Impressions)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.Emotions)
                .WithMany(e => e.Impressions);

            builder.HasIndex(i => i.BookId);
            builder.HasIndex(i => i.UserId);
        }
    }
}
