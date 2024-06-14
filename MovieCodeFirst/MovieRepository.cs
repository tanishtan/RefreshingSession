using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCodeFirst
{
    public class MovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies
                .Include(m => m.Genre)
                .ToListAsync();
        }

        public async Task<List<GenreWithMoviesDto>> GetAllGenresWithMoviesAsync()
        {
            var genresWithMovies = await _context.Genres
                .Select(g => new GenreWithMoviesDto
                {
                    GenreId = g.GenreId,
                    GenreName = g.GenreName,
                    Movies = g.Movies.Any() ? g.Movies.ToList() : null
                })
                .ToListAsync();

            return genresWithMovies;
        }
    }

    public class GenreWithMoviesDto
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
