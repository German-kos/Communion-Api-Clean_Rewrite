using Communion.Application.Common.Errors;
using ErrorOr;

namespace Communion.Application.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> SignUp(string username, string password, string name, string email);

    ErrorOr<AuthenticationResult> SignIn(string username, string password, bool remember);
}