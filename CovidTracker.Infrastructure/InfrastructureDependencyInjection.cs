using CovidTracker.Domain.Interfaces;
using CovidTracker.Infrastructure;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ILogger logger)
    {
        logger.Information("Adding Infrastructure Services");
        services.AddScoped<ICovidTrackerRepository, CovidTrackerRepository>();

        return services;
    }

    public static void AddInfratructureExtensions(this IHostApplicationBuilder builder)
    {
        builder.AddRedisClient("rediscache");
    }
}