namespace Communion.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult SignUp(string username, string password, string name, string email);

    AuthenticationResult SignIn(string username, string password, bool remember);
}