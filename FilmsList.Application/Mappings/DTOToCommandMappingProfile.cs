using AutoMapper;
using FilmsList.Application.Handlers;
using FilmsList.Application.Movies.Commands;

namespace FilmsList.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<MovieDTO, MovieCreateCommand>();
        }
    }
}