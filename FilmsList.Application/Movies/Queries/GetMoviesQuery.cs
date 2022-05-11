using FilmsList.Domain.Entities;
using MediatR;

namespace FilmsList.Application.Movies.Queries
{
    public class GetMoviesQuery : IRequest<IEnumerable<Movie>>
    {
        public string Name { get; set; }
        
        public GetMoviesQuery(string name)
        {
            Name = name;
        }
    }
}