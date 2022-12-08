using System.Net;

namespace Communion.Application.Common.Errors;

public class DuplicateUsernameException : Exception, IServiceException
{
    public DuplicateUsernameException() { }

    public DuplicateUsernameException(string? message) : base(message) { }

    public DuplicateUsernameException(string? message, Exception? innerException) : base(message, innerException) { }

    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Username already exists.";
}