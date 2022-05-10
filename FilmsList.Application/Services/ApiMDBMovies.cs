using FilmsList.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace FilmsList.Application.Services
{
    public class ApiMDBMovies : IApiMDBMovies
    {
        private readonly string _url;
        private RestResponse _response;

        public ApiMDBMovies(IConfiguration configuration)
        {
            _url = configuration.GetSection("ApiMDBMovies:Url").Value;
        }


        public async Task<RestResponse> ExecuteAsync(
            string resource, 
            Method httpMethod, 
            object body = null,
            Dictionary<string, string> customHeaders = null)
        {
            try 
            {
                _response = await ExecuteQueryAsync(
                    resource, 
                    httpMethod, 
                    body,
                    customHeaders);
            }
            catch(Exception)
            {
                throw;
            }

            return _response;
        }

        public async Task<RestResponse> ExecuteQueryAsync(
            string resource, 
            Method httpMethod, 
            object body,
            Dictionary<string, string> customHeaders = null)
        {
            var restClient = new RestClient(_url);

            var request = new RestRequest(resource, httpMethod)
                .AddHeader("Content-Type", "application/json")
                .AddHeader("X-RapidAPI-Host", "mdblist.p.rapidapi.com")
                .AddHeader("X-RapidAPI-Key", "e54b4c7dd9msh5419f7b8b700547p1bdcf3jsnf5de24c6e310");

            if (customHeaders != null)
                foreach (var header in customHeaders)
                    request.AddHeader(header.Key, header.Value);

            if (body != null)
                request.AddJsonBody(body);

            try 
            {
                return await restClient.ExecuteAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}