namespace FilmsList.Application.Movies.Commands
{
    public class MovieCreateCommand : MovieCommand
    {
        public string UserId { get; set; }
        
        public MovieCreateCommand(string userId)
        {
            UserId = userId;
        }
    }
}