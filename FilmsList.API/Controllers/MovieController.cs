using FilmsList.Application.Handlers;
using FilmsList.Domain.Validation;
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


        /// <summary>
        /// Get 3 movies from API MDB List
        /// </summary>
        /// <param name="name">Movie name</param>
        /// <returns>List with 3 valid movies</returns>
        [HttpGet()]
        [Route("name")]
        public async Task<IActionResult> GetMoviesByName(string name)
        {
            var movies = await _movieService.GetMoviesByName(name);
            
            if (movies.ToList().Count == 0 || movies == null)
                return NotFound("Movies not found");
  
            return Ok(movies);
        }

        /// <summary>
        /// Get movie by imdbId from API MDB List
        /// </summary>
        /// <param name="imdbId">Movie Identificator</param>
        /// <returns>Valid movie</returns>
        [HttpGet("{imdbId}", Name = "GetMovieById")]
        public async Task<IActionResult> GetMovieByImdbId(string imdbId)
        {
            MovieDTO movie = null; 
            try {
                try {
                    movie = await _movieService.GetMovieInApiByImdbId(imdbId);
                }
                catch(MovieNotFoundExceptionValidation e)
                {
                    return NotFound(e.Message);
                }
            }
            catch(ApplicationException e)
            {
                return BadRequest(e.Message);
            }

            return Ok(movie);
        }


        /// <summary>
        /// Get all movies from your favorite list
        /// </summary>
        /// <returns>Return list with all favorite movies</returns>
        [HttpGet]
        [Route("/api/movies")]
        public async Task<IActionResult> GetAllAdded() 
        {
            var movies = await _movieService.GetAllAdded();

            if (movies == null)
                return NotFound("Movies not found");

            return Ok(movies);
        }

        /// <summary>
        /// Get All movies by priority level from your favorite list
        /// </summary>
        /// <param name="priorityLevel">
        /// Priority level:
        ///     1 - Low | 
        ///     2 - Medium |
        ///     3 - High
        /// </param>
        /// <returns>Returns all movies according priority level</returns>
        [HttpGet]
        [Route("/api/movies/priority/{priorityLevel}")]
        public async Task<IActionResult> GetMoviesByPriority(int priorityLevel)
        {
            var movies = await _movieService.GetByPriority(priorityLevel);

            if (movies == null)
                return NotFound("Movies not found");

            return Ok(movies);
        }


        /// <summary>
        /// Add Movie to your favorite list
        /// </summary>
        /// <param name="movieDTO">JSON with Movie attributes</param>
        /// <returns>Status 201 - Created</returns>
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
        /// <summary>
        /// Delete movie from favorite list
        /// </summary>
        /// <param name="imdbId">Identificator movie</param>
        /// <returns>Status 200 - OK</returns>

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