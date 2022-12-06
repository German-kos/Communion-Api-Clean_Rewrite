using Communion.Application;
using Communion.Infrastructure;

namespace Communion.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        // Add services from other layers
        services
            .AddApplication()
            .AddInfrastructure(configuration);

        return services;
    }
}