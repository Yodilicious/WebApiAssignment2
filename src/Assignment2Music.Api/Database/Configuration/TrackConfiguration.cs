namespace Assignment2Music.Api.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            new BaseModelConfiguration<Track>().Configure(builder);

            builder.Property(t => t.TrackName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(t => t.TrackLength)
                .IsRequired();

            builder.Property(t => t.PostedOn)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.HasOne(t => t.Genre)
                .WithMany(g => g.Tracks)
                .HasForeignKey(t => t.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Artist)
                .WithMany(a => a.Tracks)
                .HasForeignKey(t => t.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
