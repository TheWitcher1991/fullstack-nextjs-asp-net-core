using backend.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<FavoriteEntity>
    {
        public void Configure(EntityTypeBuilder<FavoriteEntity> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
