using FilmsList.Domain.Entities;

namespace FilmsList.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> CreateAsync(Movie movie);
        Task<Movie> RemoveAsync(Movie movie);
        Task<Movie> UpdateAsync(Movie movie);
    }
}