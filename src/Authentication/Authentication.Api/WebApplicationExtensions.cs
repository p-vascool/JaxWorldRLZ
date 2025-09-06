using Authentication.Application.Persistance;
using Authentication.Infrastructure.Persistance.Repositories;
using JaxWorld.Common.Domain.Models.Users;
using StackExchange.Redis;

namespace Authentication.Api;

public static class WebApplicationExtensions
{
    public static IServiceCollection RegisterRedis(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));

        services.AddSingleton(sp => sp.GetRequiredService<IConnectionMultiplexer>().GetDatabase());

        services.AddScoped(typeof(IRepository<,>), typeof(RedisRepository<>));
        return services;
    }


    public static IServiceCollection AddRateLimiting(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}