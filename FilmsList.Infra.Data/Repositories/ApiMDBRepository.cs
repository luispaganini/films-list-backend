using FilmsList.Domain.Entities;
using FilmsList.Domain.Interfaces.Services;
using FilmsList.Domain.Validation;
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
                try {
                    ErrorMovie movie = JsonConvert.DeserializeObject<ErrorMovie>(apiResult.Content);
                    if (movie.isInvalid())
                        throw new MovieNotFoundExceptionValidation("Movie not found");
                    
                    Movie movieExistent = JsonConvert.DeserializeObject<Movie>(apiResult.Content);                    
                    if (movieExistent.ValidateMovie() && movie != null)
                        return movieExistent;
                }
                catch(DomainExceptionValidation)
                {
                    throw;
                }
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
                    try {
                        var movie = await GetById(result.ImdbId);
                        if (movie != null)
                            apiResultList.Add(movie);

                    }
                    catch(DomainExceptionValidation e) 
                    {
                        System.Console.WriteLine($"Item [{cont + 1}] - {e.Message}");
                    }

                    cont++;

                    if (cont == 3) break;
                    Thread.Sleep(1000);
                }
            }
                
            return apiResultList;
        }
    }
}