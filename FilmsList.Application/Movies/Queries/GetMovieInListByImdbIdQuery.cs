using FilmsList.Domain.Entities;
using MediatR;

namespace FilmsList.Application.Movies.Queries
{
    public class GetMovieInListByImdbIdQuery : IRequest<Movie>
    {
        public string ImdbId { get; set; }
        public string UserId { get; set; }



        public GetMovieInListByImdbIdQuery(string imdbId, string userId)
        {
            ImdbId = imdbId;
            UserId = userId;
        }
    }
}