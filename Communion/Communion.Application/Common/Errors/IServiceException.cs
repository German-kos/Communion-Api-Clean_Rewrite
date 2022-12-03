using System.Net;

namespace Communion.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode statusCode { get; }
    public string ErrorMessage { get; }
}