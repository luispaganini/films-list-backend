using AutoMapper;
using FilmsList.Application.Handlers;
using FilmsList.Infra.Data.Repositories;

namespace FilmsList.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IApiMDBRepository _apiMdbRepository;

        public MovieService(IMapper mapper, IApiMDBRepository apiMdbRepository)
        {
            _mapper = mapper;
            _apiMdbRepository = apiMdbRepository;
        }

        public async Task Add(MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDTO> GetById(string imdbId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByName(string name)
        {
            var result = await _apiMdbRepository.GetByNameAsync(name);
            return _mapper.Map<IEnumerable<MovieDTO>>(result);
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}