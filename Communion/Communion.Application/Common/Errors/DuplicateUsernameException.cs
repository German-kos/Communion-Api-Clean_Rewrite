using System.Net;

namespace Communion.Application.Common.Errors;

public class DuplicateUsernameException : Exception, IServiceException
{
    public HttpStatusCode statusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Username already exists.";
}