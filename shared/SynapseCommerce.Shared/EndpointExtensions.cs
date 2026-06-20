using System.Reflection;

namespace SynapseCommerce.Shared;

public static class EndpointExtensions
{
    public static IServiceCollection AddDiscoveredEndpoints(this IServiceCollection services)
    {
        // Get the current microservice's assembly
        var assembly = Assembly.GetEntryAssembly();
        if (assembly == null) return services;

        // Find all concrete classes implementing IEndpoint inside the current microservice
        var endpointTypes = assembly.GetTypes()
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        // Register classes into the DI container
        foreach (var type in endpointTypes)
        {
            services.AddTransient(typeof(IEndpoint), type);
        }

        return services;
    }

    public static WebApplication MapDiscoveredEndpoints(this WebApplication app)
    {
        // Get all the registered IEndpoint Classes from the DI container
        var endpoints = app.Services.GetServices<IEndpoint>();

        foreach (var endpoint in endpoints)
        {
            endpoint.MapRoutes(app);
        }

        return app;
    }
}