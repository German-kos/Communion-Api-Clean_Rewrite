using Communion.Application.Services.Authentication;

namespace Communion.Api.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Authentication Requests
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}