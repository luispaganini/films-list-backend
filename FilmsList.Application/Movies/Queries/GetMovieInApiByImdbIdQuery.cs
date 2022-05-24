using FilmsList.Domain.Entities;
using MediatR;

namespace FilmsList.Application.Movies.Queries
{
    public class GetMovieInApiByImdbIdQuery : IRequest<Movie>
    {
        public string ImdbId { get; set; }
        
        public GetMovieInApiByImdbIdQuery(string imdbId)
        {
            ImdbId = imdbId;
        }
    }
}