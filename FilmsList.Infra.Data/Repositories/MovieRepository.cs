using FilmsList.Domain.Entities;
using FilmsList.Domain.Interfaces;
using FilmsList.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FilmsList.Infra.Data
{
    public class MovieRepository : IMovieRepository
    {
        private ApplicationDbContext _movieContext;

        public MovieRepository(ApplicationDbContext movieContext)
        {
            _movieContext = movieContext;
        }
 
        public async Task<Movie> CreateAsync(Movie movie)
        {
            _movieContext.Add(movie);
            await _movieContext.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie> GetMovieByImdbIdAsync(string imdbId)
        {
            var movie = await _movieContext.Movies
                .SingleOrDefaultAsync(movie => movie.ImdbId == imdbId);
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetByPriorityAsync(int priorityLevel) 
        {
            if (priorityLevel > 0 && priorityLevel < 4)
                return await _movieContext.Movies
                    .Where(movie => movie.PriorityLevel == priorityLevel)
                    .ToListAsync();
            else
                return await _movieContext.Movies
                    .OrderBy(movie => movie.PriorityLevel).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _movieContext.Movies.ToListAsync();
        }

        public async Task<Movie> RemoveAsync(Movie movie)
        {
            _movieContext.Remove(movie);
            await _movieContext.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            _movieContext.Update(movie);
            await _movieContext.SaveChangesAsync();

            return movie;
        }
    }
}