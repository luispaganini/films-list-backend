using FilmsList.Application.Services;
using FilmsList.Domain.Interfaces;
using FilmsList.Domain.Interfaces.Services;
using FilmsList.Infra.Data;
using FilmsList.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsList.Infra.IoC
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddTransient<IMovieRepository, MovieRepository>();
            // services.AddScoped<IApiMDBRepository, ApiMDBRespository>();
            services.AddTransient<IApiMDBMovies, ApiMDBMovies>();

            var myHandlers = AppDomain.CurrentDomain.Load("FilmsList.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}