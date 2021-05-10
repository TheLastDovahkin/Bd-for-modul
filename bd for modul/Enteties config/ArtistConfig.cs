using bd_for_modul.Enteties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bd_for_modul.Enteties_config
{
    public class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(p => p.ArtistId);
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("Date");
            builder.Property(p => p.Phone).HasColumnName("Phone").IsRequired(false);
            builder.Property(p => p.Email).HasColumnName("Email").IsRequired(false);
            builder.Property(p => p.InstagramURL).HasColumnName("InstagramURL").IsRequired(false);
        }
    }
}
