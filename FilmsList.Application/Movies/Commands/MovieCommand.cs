using FilmsList.Domain.Entities;
using MediatR;

namespace FilmsList.Application.Movies.Commands
{
    public abstract class MovieCommand : IRequest<Movie>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImdbId { get; set; }
        public int Score { get; set; }
        public string Trailer { get; set; }
        public string Poster { get; set; }
        public string Backdrop { get; set; }
        public string UserId { get; set; }
        public int PriorityLevel { get; set; }
    }
}