using Microsoft.EntityFrameworkCore;

using Domain.Models;

namespace Domain.Context
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.PosterUrl).HasMaxLength(256);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.Summary).HasMaxLength(1024);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.VideoPosterUrl).HasMaxLength(256);

                entity.Property(e => e.VideoUrl).HasMaxLength(256);
            });
        }
    }
}
