using AutoMapper;
using FilmsList.Application.Handlers;

namespace FilmsList.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly Mapper _mapper;

        public MovieService(Mapper mapper)
        {
            _mapper = mapper;
        }

        public async Task Add(MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDTO> GetById(string imdbId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieDTO>> GetMoviesByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}