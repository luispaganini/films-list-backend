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
            var movies = await _movieService.GetMoviesByName(name);
            if (movies.ToList().Count == 0 || movies == null)
                return NotFound("Movies not found");
  
            return Ok(movies);
        }

        [HttpGet("{imdbId}")]
        public async Task<IActionResult> GetMovieById(string imdbId)
        {
            var movie = await _movieService.GetMovieById(imdbId);
            if (movie.ImdbId == null)
                return NotFound("Movie not found");

            return Ok(movie);
        }
    }
}