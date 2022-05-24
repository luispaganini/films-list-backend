using FilmsList.Application.Handlers;
using FilmsList.Application.Mappings;
using FilmsList.Application.Services;
using FilmsList.Domain.Account;
using FilmsList.Domain.Interfaces;
using FilmsList.Domain.Interfaces.Services;
using FilmsList.Infra.Data;
using FilmsList.Infra.Data.Context;
using FilmsList.Infra.Data.Identity;
using FilmsList.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsList.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IApiMDBRepository, ApiMDBRespository>();
            services.AddTransient<IApiMDBMovies, ApiMDBMovies>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IUserProvider, UserProvider>();
            services.AddTransient<IAuthenticate, AuthenticateService>();


            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myHandlers = AppDomain.CurrentDomain.Load("FilmsList.Application");
            services.AddMediatR(myHandlers);

            return services;
        }
    }
}