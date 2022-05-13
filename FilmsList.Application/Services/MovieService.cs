using AutoMapper;
using FilmsList.Application.Handlers;
using FilmsList.Application.Movies.Commands;
using FilmsList.Application.Movies.Queries;
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
            var movieCreateCommand = _mapper.Map<MovieCreateCommand>(movieDTO);
            await _mediator.Send(movieCreateCommand);
        }

        public async Task<IEnumerable<MovieDTO>> GetAllAdded()
        {
            var moviesQuery = new GetAllMoviesAddedQuery();

            if (moviesQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(moviesQuery);

            return _mapper.Map<IEnumerable<MovieDTO>>(result);
        }

        public async Task<IEnumerable<MovieDTO>> GetByPriority(int priorityLevel)
        {
            var moviesByPriority = new GetMoviesByPriorityQuery(priorityLevel);

            if (moviesByPriority == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(moviesByPriority);

            return _mapper.Map<IEnumerable<MovieDTO>>(result);
        }

        public async Task<MovieDTO> GetMovieInApiByImdbId(string imdbId)
        {
            var movieByIdQuery = new GetMovieInApiByImdbIdQuery(imdbId);
            if (movieByIdQuery == null)
                throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(movieByIdQuery);

            return _mapper.Map<MovieDTO>(result);
        }

        public async Task<MovieDTO> GetMovieInListByImdbId(string imdbId)
        {
            var movieByIdQuery = new GetMovieInListByImdbIdQuery(imdbId);
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

        public async Task Remove(string imdbId)
        {
            var movieRemoveCommand = new MovieRemoveCommand(imdbId);

            if (movieRemoveCommand == null)
                throw new Exception($"Entity could not be loaded");

            await _mediator.Send(movieRemoveCommand);
        }
    }
}