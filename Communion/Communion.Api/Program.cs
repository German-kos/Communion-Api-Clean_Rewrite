using Communion.Api.Common.Errors;
using Communion.Api.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddServices(builder.Configuration);

    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, CommunionProblemDetailsFactory>();

    builder.Services.AddEndpointsApiExplorer();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseCors(policy =>
        policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:3000")
    );
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}