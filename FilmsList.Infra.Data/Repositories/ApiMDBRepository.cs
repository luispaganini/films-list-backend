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
            if (apiResult.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Movie>(apiResult.Content);
            }
            return null;
        }

        public async Task<IEnumerable<Movie>> GetByName(string name)
        {
            List<Movie> apiResultList = new List<Movie>();
            var apiResult = await _apiMdbMovies.ExecuteAsync($"?s={name}", RestSharp.Method.Get);
            if (apiResult.IsSuccessful)
            {
                var apiContent = JsonConvert.DeserializeObject<SearchByTitle>(apiResult.Content);
                Thread.Sleep(1000);
                int cont = 0;
                foreach (var result in apiContent.Search) {
                    var movie = await GetById(result.ImdbId);
                    Thread.Sleep(1000);
                    if (movie != null)
                        apiResultList.Add(movie);
                    
                    cont++;

                    if (cont == 3) break;
                }
            }
                
            return apiResultList;
        }
    }
}