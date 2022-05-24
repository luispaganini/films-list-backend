using FilmsList.Application.Movies.Queries;
using FilmsList.Domain.Entities;
using FilmsList.Domain.Interfaces;
using MediatR;

namespace FilmsList.Application.Movies.Handlers
{
    public class GetMoviesByPriorityHandler : IRequestHandler<GetMoviesByPriorityQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesByPriorityHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> Handle(GetMoviesByPriorityQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.GetByPriorityAsync(request.PriorityLevel, request.UserId);
        }
    }
}