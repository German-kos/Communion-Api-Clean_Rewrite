using Communion.Application.Services.Password;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Communion.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped<IPasswordService, PasswordService>(); // might want to move this to another layer

        return services;
    }
}