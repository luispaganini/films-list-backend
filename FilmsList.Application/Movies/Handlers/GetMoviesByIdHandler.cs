using FilmsList.Application.Movies.Queries;
using FilmsList.Domain.Entities;
using FilmsList.Infra.Data.Repositories;
using MediatR;

namespace FilmsList.Application.Movies.Handlers
{
    public class GetMovieInApiByImdbIdHandler : IRequestHandler<GetMovieInApiByImdbIdQuery, Movie>
    {
        private readonly IApiMDBRepository _apiMdbRepository;

        public GetMovieInApiByImdbIdHandler(IApiMDBRepository apiMdbRepository)
        {
            _apiMdbRepository = apiMdbRepository;
        }

        public async Task<Movie> Handle(GetMovieInApiByImdbIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _apiMdbRepository.GetById(request.ImdbId);

            if (movie == null)
                throw new ApplicationException($"Entity could not be found.");
            
            return movie;
        }
    }
}