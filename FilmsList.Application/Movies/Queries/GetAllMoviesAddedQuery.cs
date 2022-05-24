using FilmsList.Domain.Entities;
using MediatR;

namespace FilmsList.Application.Movies.Queries
{
    public class GetAllMoviesAddedQuery : IRequest<IEnumerable<Movie>>
    {
        public string UserId { get; set; }

        public GetAllMoviesAddedQuery(string userId)
        {
            UserId = userId;
        }
    }
}