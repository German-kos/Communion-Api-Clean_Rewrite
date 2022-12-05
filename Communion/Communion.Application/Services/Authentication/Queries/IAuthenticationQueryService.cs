using Communion.Application.Services.Authentication.Common;
using ErrorOr;

namespace Communion.Application.Services.Authentication;

public interface IAuthenticationQueryService
{
    ErrorOr<AuthenticationResult> SignIn(string username, string password, bool remember);
}