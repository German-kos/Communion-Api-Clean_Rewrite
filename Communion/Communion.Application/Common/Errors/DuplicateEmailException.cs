using System.Net;

namespace Communion.Application.Common.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    public DuplicateEmailException() { }

    public DuplicateEmailException(string? message) : base(message) { }

    public DuplicateEmailException(string? message, Exception? innerException) : base(message, innerException) { }

    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already exists.";
}
