using FilmsList.Domain.Entities;
using MediatR;

namespace FilmsList.Application.Movies.Queries
{
    public class GetMovieByIdQuery : IRequest<Movie>
    {
        public string ImdbId { get; set; }
        
        public GetMovieByIdQuery(string imdbId)
        {
            ImdbId = imdbId;
        }
    }
}