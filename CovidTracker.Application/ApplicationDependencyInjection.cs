using CovidTracker.Domain.Interfaces;
using Serilog;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        List<System.Reflection.Assembly> mediatRAssemblies,
        ILogger logger)
    {
        logger.Information("Adding Application Services");
        mediatRAssemblies.Add(typeof(ApplicationDependencyInjection).Assembly);
        return services;
    }
}
