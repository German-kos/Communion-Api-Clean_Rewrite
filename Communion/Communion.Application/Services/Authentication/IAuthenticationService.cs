using Communion.Application.Common.Errors;
using FluentResults;

namespace Communion.Application.Services.Authentication;

public interface IAuthenticationService
{
    Result<AuthenticationResult> SignUp(string username, string password, string name, string email);

    AuthenticationResult SignIn(string username, string password, bool remember);
}