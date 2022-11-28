using Communion.Application.Common.Interfaces.Authentication;
using Communion.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Communion.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        return services;
    }
}