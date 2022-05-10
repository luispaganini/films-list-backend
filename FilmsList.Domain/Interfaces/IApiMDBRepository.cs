using FilmsList.Domain.Entities;
using RestSharp;

namespace FilmsList.Infra.Data.Repositories
{
    public interface IApiMDBRepository
    {
         Task<IEnumerable<Movie>> GetByNameAsync(string name);
         Task<Movie> GetById(string imdbId);

    }
}