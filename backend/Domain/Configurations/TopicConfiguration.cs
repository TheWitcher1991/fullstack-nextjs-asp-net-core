﻿using backend.Domain.Entities;
using backend.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Domain.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<TopicEntity>
    {
        public void Configure(EntityTypeBuilder<TopicEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(Config.MAX_TITLE_LENGTH);

            builder.HasMany(t => t.Categories)
                .WithOne(c => c.Topic)
                .HasForeignKey(c => c.TopicId);

            builder.HasIndex(t => t.Title);
        }
    }
}
