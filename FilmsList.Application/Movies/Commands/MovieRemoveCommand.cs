namespace FilmsList.Application.Movies.Commands
{
    public class MovieRemoveCommand : MovieCommand
    {
        public string ImdbId { get; set; }

        public MovieRemoveCommand(string imdbId)
        {
            ImdbId = imdbId;
        }
    }
}