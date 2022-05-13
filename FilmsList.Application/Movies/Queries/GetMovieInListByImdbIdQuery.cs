using FilmsList.Domain.Entities;
using MediatR;

namespace FilmsList.Application.Movies.Queries
{
    public class GetMovieInListByImdbIdQuery : IRequest<Movie>
    {
        public string ImdbId { get; set; }
        
        public GetMovieInListByImdbIdQuery(string imdbId)
        {
            ImdbId = imdbId;
        }
    }
}