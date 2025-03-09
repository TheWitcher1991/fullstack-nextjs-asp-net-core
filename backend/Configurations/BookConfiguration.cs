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

            builder.Property(b => b.Price).IsRequired();
        }
    }
}
