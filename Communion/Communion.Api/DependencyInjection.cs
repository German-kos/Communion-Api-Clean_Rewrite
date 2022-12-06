using Communion.Api.Common.Errors;
using Communion.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Communion.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSingleton<ProblemDetailsFactory, CommunionProblemDetailsFactory>();
        services.AddMapping();

        return services;
    }
}