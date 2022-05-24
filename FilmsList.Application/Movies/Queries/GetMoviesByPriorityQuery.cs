using FilmsList.Domain.Entities;
using MediatR;

namespace FilmsList.Application.Movies.Queries
{
    public class GetMoviesByPriorityQuery : IRequest<IEnumerable<Movie>>
    {
        public int PriorityLevel { get; set; }
        public string UserId { get; set; }



        public GetMoviesByPriorityQuery(int priorityLevel, string userId)
        {
            PriorityLevel = priorityLevel;
            UserId = userId;
        }
    }
}