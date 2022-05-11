namespace FilmsList.Application.Handlers
{
    public interface IMovieService
    {
         Task<IEnumerable<MovieDTO>> GetMoviesByName(string name);
         Task<MovieDTO> GetMovieById(string imdbId);
         Task Add(MovieDTO movieDTO);
         Task Remove(int id);
    }
}