namespace Assignment2Music.Api.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            new BaseModelConfiguration<Review>().Configure(builder);

            builder.Property(r => r.ReviewText)
                .HasMaxLength(512)
                .IsRequired();

            builder.Property(r => r.ReviewedOn)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.HasOne(r => r.Artist)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Track)
                .WithMany(t => t.Reviews)
                .HasForeignKey(r => r.TrackId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
