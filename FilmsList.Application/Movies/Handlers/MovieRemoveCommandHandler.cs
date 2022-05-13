using FilmsList.Application.Movies.Commands;
using FilmsList.Domain.Entities;
using FilmsList.Domain.Interfaces;
using MediatR;

namespace FilmsList.Application.Movies.Handlers
{
    public class MovieRemoveCommandHandler : IRequestHandler<MovieRemoveCommand, Movie>
    {
        private readonly IMovieRepository _movieRepository;

        public MovieRemoveCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> Handle(MovieRemoveCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieByImdbIdAsync(request.ImdbId);
            if (movie == null)
                throw new ApplicationException($"Entity could not be found");
            else
                return await _movieRepository.RemoveAsync(movie);
        }
    }
}