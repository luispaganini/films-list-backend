using FilmsList.Application.Services;
using FilmsList.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmsList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IApiMDBMovies _apiMdbMovies;

        public TestController(IApiMDBMovies apiMdbMovies)
        {
            _apiMdbMovies = apiMdbMovies;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            return Ok();
        }
    }
}