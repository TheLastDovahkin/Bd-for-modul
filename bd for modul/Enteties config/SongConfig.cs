using bd_for_modul.Enteties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace bd_for_modul.Enteties_config
{
    class SongConfig : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(p => p.SongId);
            builder.Property(p => p.SongTitle).HasColumnName("SongTitle");
            builder.Property(p => p.Duration).HasColumnName("Duration").HasColumnType("Time");
            builder.Property(p => p.ReleasedDate).HasColumnName("ReleasedDate");
            builder.Property(p => p.GenreId).HasColumnName("SongGenre");

            builder.HasMany(d => d.Artists)
                .WithMany(p => p.Songs)
                .UsingEntity<Dictionary<string, object>>(
                    "Supply",
                    j => j
                        .HasOne<Artist>()
                        .WithMany()
                        .HasForeignKey("ArtistId"),
                    j => j
                        .HasOne<Song>()
                        .WithMany()
                        .HasForeignKey("SongId"));
        }
    }
}
