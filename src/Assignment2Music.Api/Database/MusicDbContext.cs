namespace Assignment2Music.Api.Database
{
    using Configuration;
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class MusicDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new TrackConfiguration());
        }

        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            : base(options) {  }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}
