namespace Assignment2Music.Api.Database.Configuration
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            new BaseModelConfiguration<Artist>().Configure(builder);

            builder.Property(a => a.FirstName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(a => a.ArtistName)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(a => a.Username)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(a => a.Password)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
