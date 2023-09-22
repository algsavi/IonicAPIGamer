
using IonicAPIGamer.Application.Interfaces;
using IonicAPIGamer.Application.Services;
using IonicAPIGamer.Domain.Interfaces;
using IonicAPIGamer.Infra.Data.Context;
using IonicAPIGamer.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IonicApiGamer.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ApplicationConnection");

        services.AddDbContext<IonicApiGamerDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGameService, GameService>();

        return services;
    }
}