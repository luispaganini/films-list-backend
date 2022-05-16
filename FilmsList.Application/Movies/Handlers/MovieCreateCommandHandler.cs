using FilmsList.Application.Movies.Commands;
using FilmsList.Domain.Entities;
using FilmsList.Domain.Interfaces;
using MediatR;

namespace FilmsList.Application.Movies.Handlers
{
    public class MovieCreateCommandHandler : IRequestHandler<MovieCreateCommand, Movie>
    {
        private readonly IMovieRepository _movieRepository;

        public MovieCreateCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> Handle(MovieCreateCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie(
                request.Title, 
                request.Description, 
                request.ImdbId,
                request.Score,
                request.Trailer,
                request.Poster,
                request.Backdrop,
                request.Response,
                request.PriorityLevel);

            if (movie == null)
                throw new ApplicationException($"Error creating entity.");
            else
                return await _movieRepository.CreateAsync(movie);
        }
    }
}