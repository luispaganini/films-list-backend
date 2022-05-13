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

        [HttpGet()]
        [Route("name")]
        public async Task<IActionResult> GetMoviesByName(string name)
        {
            var movies = await _movieService.GetMoviesByName(name);
            
            if (movies.ToList().Count == 0 || movies == null)
                return NotFound("Movies not found");
  
            return Ok(movies);
        }

        [HttpGet("{imdbId}", Name = "GetMovieById")]
        public async Task<IActionResult> GetMovieByImdbId(string imdbId)
        {
            var movie = await _movieService.GetMovieInApiByImdbId(imdbId);
            if (movie.ImdbId == null)
                return NotFound("Movie not found");

            return Ok(movie);
        }

        [HttpGet]
        [Route("/api/movies")]
        public async Task<IActionResult> GetAllAdded() 
        {
            var movies = await _movieService.GetAllAdded();

            if (movies == null)
                return NotFound("Movies not found");

            return Ok(movies);
        }

        [HttpGet]
        [Route("/api/movies/priority/{priorityLevel}")]
        public async Task<IActionResult> GetMoviesByPriority(int priorityLevel)
        {
            var movies = await _movieService.GetByPriority(priorityLevel);

            if (movies == null)
                return NotFound("Movies not found");

            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] MovieDTO movieDTO)
        {
            if (movieDTO == null)
                return BadRequest("Invalid data");
            
            try {
                await _movieService.Add(movieDTO);
            } 
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }

            return new CreatedAtRouteResult("GetMovieById", movieDTO, movieDTO);
        }

        [HttpDelete("{imdbId}")]
        public async Task<IActionResult> DeleteMovieFromList(string imdbId)
        {
            var movieDTO = await _movieService.GetMovieInListByImdbId(imdbId);
            
            if (movieDTO == null)
                return NotFound("Movie not found");

            await _movieService.Remove(imdbId);

            return Ok(movieDTO);
        }
    }
}