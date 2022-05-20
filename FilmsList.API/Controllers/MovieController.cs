using FilmsList.Application.DTOs;
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
            MovieApiDTO movie = null; 
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
        /// <remark>
        /// {
        ///    "title": "Jaws",
        ///    "description": "When an insatiable great white shark terrorizes the townspeople of Amity Island, the police chief, an oceanographer and a grizzled shark hunter seek to destroy the blood-thirsty beast.",
        ///    "imdbId": "tt0073195",
        ///    "score": 5,
        ///    "trailer": "http://youtube.com/watch?v=U1fu_sA7XhE",
        ///    "poster": "https://image.tmdb.org/t/p/original/s2xcqSFfT6F7ZXHxowjxfG0yisT.jpg",
        ///    "backdrop": "https://image.tmdb.org/t/p/w1920_and_h800_multi_faces//3nYlM34QhzdtAvWRV5bN4nLtnTc.jpg",
        ///    "priorityLevel": 3
        ///  }
        /// </remark>
        /// <param name="movieDTO">JSON with Movie attributes</param>
        /// <returns>Status 201 - Created</returns>
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] MovieDTO movieDTO)
        {

            var movie = await _movieService.GetMovieInListByImdbId(movieDTO.ImdbId);
            if (movie != null)
                return BadRequest("This movie already exists");            

            try {
                await _movieService.Add(movieDTO);
                return new CreatedAtRouteResult("GetMovieById", movieDTO, movieDTO);
            } 
            catch (ApplicationException e) 
            {
                return BadRequest(e.Message);
            }
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