using FilmsList.Domain.Entities;

namespace FilmsList.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetByPriorityAsync(int priorityLevel);
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieByImdbIdAsync(string imdbId);
        Task<Movie> CreateAsync(Movie movie);
        Task<Movie> RemoveAsync(Movie movie);
        Task<Movie> UpdateAsync(Movie movie);
    }
}