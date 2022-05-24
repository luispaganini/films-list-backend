using FilmsList.Application.Movies.Queries;
using FilmsList.Domain.Entities;
using FilmsList.Domain.Interfaces;
using MediatR;

namespace FilmsList.Application.Movies.Handlers
{
    public class GetMovieInListByImdbId : IRequestHandler<GetMovieInListByImdbIdQuery, Movie>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMovieInListByImdbId(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> Handle(GetMovieInListByImdbIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieByImdbIdAsync(request.ImdbId, request.UserId);

            if (movie == null)
                throw new ApplicationException($"Entity could not be found.");
            
            return movie;
        }
    }
}