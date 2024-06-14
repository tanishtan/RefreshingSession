using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCodeFirst
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<MovieDbContext>();

                try
                {
                    context.Database.Migrate();
                    SeedDb(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while migrating or seeding the database: {ex.Message}");
                }

                var movieRepo = new MovieRepository(context);

                Console.WriteLine("1. List of all movies with their genres:");
                var movies = await movieRepo.GetAllMoviesAsync();
                foreach (var movie in movies)
                {
                    Console.WriteLine($"   Title: {movie.Title}, Genre: {movie.Genre?.GenreName ?? "N/A"}, Release Date: {movie.ReleaseDate.ToShortDateString()}, Production House: {movie.ProductionHouse}");
                }

                Console.WriteLine("\n2. List of all genres with their movies:");
                var genres = await movieRepo.GetAllGenresWithMoviesAsync();
                foreach (var genre in genres)
                {
                    Console.WriteLine($"   Genre: {genre.GenreName}");
                    if (genre.Movies != null && genre.Movies.Any())
                    {
                        foreach (var movie in genre.Movies)
                        {
                            Console.WriteLine($"      Title: {movie.Title}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"      No movies available for this genre.");
                    }
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<MovieDbContext>(options =>
                        options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MovieDb;Trusted_Connection=True;MultipleActiveResultSets=true;"));
                    services.AddScoped<MovieRepository>();
                });

        private static void SeedDb(MovieDbContext context)
        {
            if (!context.Genres.Any())
            {
                context.Genres.AddRange(
                    new Genre { GenreId = 1, GenreName = "Horror" },
                    new Genre { GenreId = 2, GenreName = "Thriller" },
                    new Genre { GenreId = 3, GenreName = "Fiction" },
                    new Genre { GenreId = 4, GenreName = "Action" },
                    new Genre { GenreId = 5, GenreName = "Romance" },
                    new Genre { GenreId = 6, GenreName = "Adventure" }
                );
                context.SaveChanges();
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(
                    new Movie { Title = "Scary Movie", GenreId = 1, ReleaseDate = new DateTime(2000, 7, 7), ProductionHouse = "Dimension Films" },
                    new Movie { Title = "The Conjuring", GenreId = 1, ReleaseDate = new DateTime(2013, 7, 19), ProductionHouse = "New Line Cinema" },
                    new Movie { Title = "Inception", GenreId = 3, ReleaseDate = new DateTime(2010, 7, 16), ProductionHouse = "Warner Bros." }
                );
                context.SaveChanges();
            }
        }
    }
}
