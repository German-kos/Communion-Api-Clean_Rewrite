using Communion.Application.Common.Errors;
using OneOf;

namespace Communion.Application.Services.Authentication;

public interface IAuthenticationService
{
    OneOf<AuthenticationResult, SignUpError> SignUp(string username, string password, string name, string email);

    OneOf<AuthenticationResult, SignInError> SignIn(string username, string password, bool remember);
}