using FilmsList.Domain.Entities;
using FilmsList.Domain.Interfaces.Services;
using FilmsList.Infra.Data.Repositories;
using Newtonsoft.Json;

namespace FilmsList.Infra.Data
{
    public class ApiMDBRespository : IApiMDBRepository
    {
        private readonly IApiMDBMovies _apiMdbMovies;

        public ApiMDBRespository(IApiMDBMovies apiMdbMovies)
        {
            _apiMdbMovies = apiMdbMovies;
        }
        public async Task<Movie> GetById(string imdbId)
        {
            var apiResult = await _apiMdbMovies.ExecuteAsync($"?i={imdbId}", RestSharp.Method.Get);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetByNameAsync(string name)
        {
            IEnumerable<Movie> apiResultList = new List<Movie>();
            var apiResult = await _apiMdbMovies.ExecuteAsync($"?s={name}", RestSharp.Method.Get);
            if (apiResult.IsSuccessful)
            {
                var test = JsonConvert.DeserializeObject<List<object>>(apiResult.Content);
                //apiResultList = JsonConvert.DeserializeObject<IEnumerable<Movie>>(apiResult.Content);
                foreach (var test1 in test) {
                    System.Console.WriteLine(test1);
                }
            }
                
            return apiResultList;
        }
    }
}