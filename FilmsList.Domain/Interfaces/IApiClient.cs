using RestSharp;

namespace FilmsList.Domain.Interfaces.Services
{
    public interface IApiClient
    {
        Task<RestResponse> ExecuteAsync(
            string resource, 
            Method httpMethod, 
            object body = null, 
            Dictionary<string, string> 
            customHeaders = null);
    }
}