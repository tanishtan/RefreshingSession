using Microsoft.EntityFrameworkCore;
using System;

namespace MovieCodeFirst
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, GenreName = "Horror" },
                new Genre { GenreId = 2, GenreName = "Thriller" },
                new Genre { GenreId = 3, GenreName = "Fiction" },
                new Genre { GenreId = 4, GenreName = "Action" },
                new Genre { GenreId = 5, GenreName = "Romance" },
                new Genre { GenreId = 6, GenreName = "Adventure" }
            );

            modelBuilder.SeedDb();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void SeedDb(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Title = "Scary Movie", GenreId = 1, ReleaseDate = new DateTime(2000, 7, 7), ProductionHouse = "Dimension Films" },
                new Movie { MovieId = 2, Title = "The Conjuring", GenreId = 1, ReleaseDate = new DateTime(2013, 7, 19), ProductionHouse = "New Line Cinema" },
                new Movie { MovieId = 3, Title = "Inception", GenreId = 3, ReleaseDate = new DateTime(2010, 7, 16), ProductionHouse = "Warner Bros." }
            );
        }
    }
}
