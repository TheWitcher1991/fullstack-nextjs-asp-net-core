using backend.Domain.Entities;
using backend.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Domain.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title).IsRequired().HasMaxLength(Config.MAX_TITLE_LENGTH);

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(c => c.Topic)
                .WithMany(t => t.Categories)
                .HasForeignKey(c => c.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Books)
                .WithMany(b => b.Categories);

            builder.HasIndex(c => c.Title);
            builder.HasIndex(c => c.TopicId);
        }
    }
}
