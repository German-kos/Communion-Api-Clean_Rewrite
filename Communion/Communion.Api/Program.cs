using Communion.Api.Errors;
using Communion.Api.Extensions;
using Communion.Api.Filters;
using Communion.Api.Middleware;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddServices(builder.Configuration);

    // demo for error handling filter
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, CommunionProblemDetailsFactory>();

    builder.Services.AddEndpointsApiExplorer();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseCors(policy =>
        policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:3000")
    );

    // demo for exception handling middleware
    // app.UseMiddleware<ExceptionHandlingMiddleware>();

    app.UseExceptionHandler("/error");
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}