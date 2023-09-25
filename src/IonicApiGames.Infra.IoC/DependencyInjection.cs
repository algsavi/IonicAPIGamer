
using IonicAPIGamer.Application.Interfaces;
using IonicAPIGamer.Application.Services;
using IonicAPIGamer.Domain.Interfaces;
using IonicAPIGamer.Infra.Data.Context;
using IonicAPIGamer.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using IonicAPIGamer.Infra.Caching;

namespace IonicApiGamer.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlConnectionString = configuration.GetConnectionString("sqlConnectionString");
        var redisConnectionString = configuration.GetConnectionString("redisConnectionString");

        services.AddDbContext<IonicApiGamerDbContext>(options => {
            options.UseSqlServer(sqlConnectionString);
        });

        services.AddStackExchangeRedisCache(options => {
            options.InstanceName = "redis-instance-";
            options.Configuration = redisConnectionString;
        });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<ICachingService, CachingService>();

        return services;
    }
}