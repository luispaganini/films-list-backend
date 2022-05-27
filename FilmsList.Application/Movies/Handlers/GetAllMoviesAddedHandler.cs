using FilmsList.Application.Movies.Queries;
using FilmsList.Domain.Entities;
using FilmsList.Domain.Interfaces;
using MediatR;

namespace FilmsList.Application.Movies.Handlers
{
    public class GetAllMoviesAddedHandler : IRequestHandler<GetAllMoviesAddedQuery, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllMoviesAddedHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> Handle(GetAllMoviesAddedQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.GetMoviesAsync();
        }
    }
}