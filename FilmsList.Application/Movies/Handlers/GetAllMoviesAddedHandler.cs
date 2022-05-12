using FilmsList.Application.Movies.Queries;
using FilmsList.Domain.Entities;
using FilmsList.Domain.Interfaces;
using MediatR;

namespace FilmsList.Application.Movies.Handlers
{
    public class GetAllMoviesAddedHandler : IRequestHandler<GetAllMoviesAdded, IEnumerable<Movie>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllMoviesAddedHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> Handle(GetAllMoviesAdded request, CancellationToken cancellationToken)
        {
            return await _movieRepository.GetMoviesAsync();
        }
    }
}