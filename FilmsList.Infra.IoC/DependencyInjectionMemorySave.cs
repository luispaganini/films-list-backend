using FilmsList.Application.Handlers;
using FilmsList.Application.Mappings;
using FilmsList.Application.Services;
using FilmsList.Domain.Interfaces;
using FilmsList.Domain.Interfaces.Services;
using FilmsList.Infra.Data;
using FilmsList.Infra.Data.Context;
using FilmsList.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsList.Infra.IoC
{
    public static class DependencyInjectionMemorySave
    {
        public static IServiceCollection AddInfrastructureInMemory(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("FilmsList")
            );

            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IApiMDBRepository, ApiMDBRespository>();
            services.AddTransient<IApiMDBMovies, ApiMDBMovies>();
            services.AddTransient<IMovieService, MovieService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


            var myHandlers = AppDomain.CurrentDomain.Load("FilmsList.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}