namespace FilmsList.Application.Movies.Queries
{
    public class GetMovieByIdQuery : GetMoviesQuery
    {
        public int Id { get; set; }
        
        public GetMovieByIdQuery(int id)
        {
            Id = id;
        }
    }
}