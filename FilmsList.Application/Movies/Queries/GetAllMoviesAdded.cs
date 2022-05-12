using FilmsList.Domain.Entities;
using MediatR;

namespace FilmsList.Application.Movies.Queries
{
    public class GetAllMoviesAdded : IRequest<IEnumerable<Movie>>
    {
        
    }
}