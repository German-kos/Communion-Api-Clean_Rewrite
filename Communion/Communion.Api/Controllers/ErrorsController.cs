using Communion.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Communion.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists."),
            DuplicateUsernameException => (StatusCodes.Status409Conflict, "Username already exists."),
            UserNotFoundException => (StatusCodes.Status404NotFound, "User does not exist."),
            WrongPasswordException => (StatusCodes.Status409Conflict, "Wrong password."),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error has occured.")
        };

        return Problem(statusCode: statusCode, title: message);
    }
}