using FilmsList.Application.Movies.Queries;
using FilmsList.Domain.Entities;
using FilmsList.Infra.Data.Repositories;
using MediatR;

namespace FilmsList.Application.Movies.Handlers
{
    public class GetMoviesByNameHandler : IRequestHandler<GetMoviesQuery, IEnumerable<Movie>>
    {
        private readonly IApiMDBRepository _apiMdbRepository;

        public GetMoviesByNameHandler(IApiMDBRepository apiMdbRepository)
        {
            _apiMdbRepository = apiMdbRepository;
        }

        public async Task<IEnumerable<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _apiMdbRepository.GetByName(request.Name);
        }
    }
}