namespace FilmsList.Application.Movies.Commands
{
    public class MovieRemoveCommand : MovieCommand
    {
        public string ImdbId { get; set; }
        public string UserId { get; set; }

        public MovieRemoveCommand(string imdbId, string userId)
        {
            ImdbId = imdbId;
            UserId = userId;
        }
    }
}