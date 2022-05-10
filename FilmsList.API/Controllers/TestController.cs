using FilmsList.Application.Handlers;
using FilmsList.Application.Services;
using FilmsList.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilmsList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public TestController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var result = await _movieService.GetMoviesByName(name);
            return Ok();
        }
    }
}