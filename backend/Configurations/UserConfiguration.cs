using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(Config.MAX_TITLE_LENGTH);

            builder.Property(u => u.LastName).IsRequired().HasMaxLength(Config.MAX_TITLE_LENGTH);

            builder.Property(u => u.Email).IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
