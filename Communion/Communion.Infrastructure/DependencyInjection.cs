using Communion.Application.Common.Interfaces.Authentication;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Application.Common.Interfaces.Services;
using Communion.Infrastructure.Authentication;
using Communion.Infrastructure.Persistence;
using Communion.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Communion.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<JwtSettings>(config.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}