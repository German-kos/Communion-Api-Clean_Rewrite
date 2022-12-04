using System.Net;

namespace Communion.Application.Common.Errors;

public class WrongPasswordException : Exception, IServiceException
{
    public HttpStatusCode statusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Wrong password.";
}