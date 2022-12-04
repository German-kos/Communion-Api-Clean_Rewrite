using System.Net;

namespace Communion.Application.Common.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode statusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already exists.";
}
