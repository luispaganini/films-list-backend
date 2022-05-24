using FilmsList.Application.DTOs;
using FilmsList.Domain.Entities;

namespace FilmsList.Application.Handlers
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetAllAdded(string userId);
        Task<IEnumerable<MovieDTO>> GetByPriority(int priorityLevel, string userId);
        Task<IEnumerable<MovieApiDTO>> GetMoviesByName(string name);
        Task<MovieApiDTO> GetMovieInApiByImdbId(string imdbId);
        Task<MovieDTO> GetMovieInListByImdbId(string imdbId, string userId);
        Task Add(MovieDTO movieDTO);
        Task Remove(string imdbId, string userId);
    }
}