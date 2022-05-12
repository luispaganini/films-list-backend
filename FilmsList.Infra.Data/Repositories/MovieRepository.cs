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

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _movieContext.Movies.SingleOrDefaultAsync(movie => movie.Id == id);
            return movie;
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