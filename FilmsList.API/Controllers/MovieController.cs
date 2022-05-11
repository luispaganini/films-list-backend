using FilmsList.Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace FilmsList.API.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesByName(string name)
        {
            var result = await _movieService.GetMoviesByName(name);
            return Ok(result);
        }

        [HttpGet("{imdbId}")]
        public async Task<IActionResult> GetMovieById(string imdbId)
        {
            var result = await _movieService.GetMovieById(imdbId);
            return Ok(result);
        }
    }
}