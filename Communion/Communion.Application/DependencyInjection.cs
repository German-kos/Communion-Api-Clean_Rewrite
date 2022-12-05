using Communion.Application.Services.Authentication;
using Communion.Application.Services.Authentication.Commands;
using Communion.Application.Services.Authentication.Queries;
using Communion.Application.Services.Password;
using Microsoft.Extensions.DependencyInjection;

namespace Communion.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

        services.AddScoped<IPasswordService, PasswordService>(); // might want to move this to another layer

        return services;
    }
}