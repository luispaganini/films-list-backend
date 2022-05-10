namespace FilmsList.Application.Handlers
{
    public interface IMovieService
    {
         Task<IEnumerable<MovieDTO>> GetMoviesByName(string name);
         Task<MovieDTO> GetById(string imdbId);
         Task Add(MovieDTO movieDTO);
         Task Remove(int id);
    }
}