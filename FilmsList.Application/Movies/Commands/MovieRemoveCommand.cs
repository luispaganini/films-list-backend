namespace FilmsList.Application.Movies.Commands
{
    public class MovieRemoveCommand : MovieCommand
    {
        public int Id { get; set; }
        
        
        public MovieRemoveCommand(int id)
        {
            Id = id;
        }
    }
}