using backend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace backend.Configurations
{
    public class EmotionConfiguration : IEntityTypeConfiguration<EmotionEntity>
    {
        public void Configure(EntityTypeBuilder<EmotionEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(e => e.Label)
                .IsRequired()
                .HasMaxLength(Config.MAX_DESCRIPTION_LENGTH);

            builder.Property(e => e.Unicode)
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasMany(e => e.Impressions)
                .WithMany(i => i.Emotions);

        }
    }
}
