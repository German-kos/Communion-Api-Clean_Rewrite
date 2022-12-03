using System.Net;

namespace Communion.Application.Common.Errors;

public class UserNotFoundException : Exception, IServiceException
{
    public HttpStatusCode statusCode => HttpStatusCode.NotFound;

    public string ErrorMessage => "Username not found.";
}