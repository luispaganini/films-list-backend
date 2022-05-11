using AutoMapper;
using FilmsList.Application.Handlers;
using FilmsList.Application.Movies.Queries;
using FilmsList.Infra.Data.Repositories;
using MediatR;

namespace FilmsList.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public MovieService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Add(MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieDTO> GetMovieById(string imdbId)
        {
            var movieByIdQuery = new GetMovieByIdQuery(imdbId);
            if (movieByIdQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(movieByIdQuery);

            return _mapper.Map<MovieDTO>(result);
        }

        public async Task<IEnumerable<MovieDTO>> GetMoviesByName(string name)
        {
            var moviesByNameQuery = new GetMoviesQuery(name);
            if (moviesByNameQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(moviesByNameQuery);
            return _mapper.Map<IEnumerable<MovieDTO>>(result);
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}