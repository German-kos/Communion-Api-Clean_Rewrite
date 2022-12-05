using Communion.Application;
using Communion.Infrastructure;

namespace Communion.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        // Add services from other layers
        services
            .AddApplication()
            .AddInfrastructure(config);

        return services;
    }
}