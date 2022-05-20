using AutoMapper;
using FilmsList.Application.DTOs;
using FilmsList.Application.Handlers;
using FilmsList.Domain.Entities;

namespace FilmsList.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Movie, MovieApiDTO>().ReverseMap();
        }
    }
}