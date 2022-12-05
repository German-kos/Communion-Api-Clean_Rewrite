using System.Net;

namespace Communion.Application.Common.Errors;

public class WrongPasswordException : Exception, IServiceException
{
    public WrongPasswordException() { }
    public WrongPasswordException(string? message) : base(message) { }

    public WrongPasswordException(string? message, Exception? innerException) : base(message, innerException) { }

    public HttpStatusCode statusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Wrong password.";
}