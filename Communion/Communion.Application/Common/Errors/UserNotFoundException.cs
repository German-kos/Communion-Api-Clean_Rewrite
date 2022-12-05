using System.Net;

namespace Communion.Application.Common.Errors;

public class UserNotFoundException : Exception, IServiceException
{
    public UserNotFoundException() { }

    public UserNotFoundException(string? message) : base(message) { }

    public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException) { }

    public HttpStatusCode statusCode => HttpStatusCode.NotFound;

    public string ErrorMessage => "Username not found.";
}