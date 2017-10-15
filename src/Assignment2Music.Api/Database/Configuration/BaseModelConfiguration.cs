namespace Assignment2Music.Api.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BaseModelConfiguration<T> : IEntityTypeConfiguration<T> where T: BaseModel
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasQueryFilter(a => !a.IsDeleted);

            builder.HasKey(m => m.RecordId);

            builder.Property(m => m.RecordId)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(m => m.IsDeleted)
                .IsRequired();
        }
    }
}
