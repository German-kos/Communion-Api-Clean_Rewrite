using System.Reflection;
using Communion.Application.Authentication.Commands.SignUp;
using Communion.Application.Authentication.Common;
using Communion.Application.Common.Behaviors;
using Communion.Application.Services.Password;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Communion.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        // Before MediatR invokes the handler, it wraps in whatever implements the IPipelineBehavior or the types that correspond to the type of the request that's now executing
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IPasswordService, PasswordService>(); // might want to move this to another layer

        return services;
    }
}