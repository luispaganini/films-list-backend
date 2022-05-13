using FilmsList.Domain.Entities;

namespace FilmsList.Application.Handlers
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetAllAdded();
        Task<IEnumerable<MovieDTO>> GetByPriority(int priorityLevel);
        Task<IEnumerable<MovieDTO>> GetMoviesByName(string name);
        Task<MovieDTO> GetMovieInApiByImdbId(string imdbId);
        Task<MovieDTO> GetMovieInListByImdbId(string imdbId);
        Task Add(MovieDTO movieDTO);
        Task Remove(string imdbId);
    }
}