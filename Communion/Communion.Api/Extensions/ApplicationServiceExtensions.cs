using Communion.Application;
using Communion.Application.Services.Authentication;
using Communion.Infrastructure;

namespace Communion.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // Add services from other layers
        services
            .AddApplication()
            .AddInfrastructure();

        return services;
    }
}