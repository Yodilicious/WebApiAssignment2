namespace Assignment2Music.Api.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            new BaseModelConfiguration<Genre>().Configure(builder);

            builder.Property(g => g.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(g => g.Description)
                .HasMaxLength(512)
                .IsRequired();
        }
    }
}
