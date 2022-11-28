using Communion.Application.Common.Interfaces.Authentication;
using Communion.Application.Common.Interfaces.Services;
using Communion.Infrastructure.Authentication;
using Communion.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Communion.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}