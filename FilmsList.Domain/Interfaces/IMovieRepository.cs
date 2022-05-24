using FilmsList.Domain.Entities;

namespace FilmsList.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetByPriorityAsync(int priorityLevel, string userId);
        Task<IEnumerable<Movie>> GetMoviesAsync(string userId);
        Task<Movie> GetMovieByImdbIdAsync(string imdbId, string userId);
        Task<Movie> CreateAsync(Movie movie);
        Task<Movie> RemoveAsync(Movie movie);
        Task<Movie> UpdateAsync(Movie movie);
    }
}