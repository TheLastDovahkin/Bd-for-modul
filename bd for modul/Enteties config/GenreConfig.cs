using bd_for_modul.Enteties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bd_for_modul.Enteties_config
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(p => p.GenreId);
            builder.Property(p => p.Title).HasColumnName("Title");

            builder.HasMany(z => z.Songs)
                .WithOne(x => x.Genre)
                .HasForeignKey(z => z.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
