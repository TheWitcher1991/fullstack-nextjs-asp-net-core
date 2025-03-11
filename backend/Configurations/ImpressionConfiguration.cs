using backend.Entities;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Configurations
{
    public class ImpressionConfiguration : IEntityTypeConfiguration<ImpressionEntity>
    {
        public void Configure(EntityTypeBuilder<ImpressionEntity> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Text).IsRequired().HasMaxLength(Config.MAX_DESCRIPTION_LENGTH);

            builder.HasOne(i => i.User)
                .WithMany(u => u.Impressions)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Book)
                .WithMany(b => b.Impressions)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
