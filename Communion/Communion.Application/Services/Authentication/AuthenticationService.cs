namespace Communion.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    public AuthenticationResult SignIn(string username, string password, bool remember)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            username,
            "name goes here",
            "email goes here",
            "pfp url goes here",
            "token goes here",
            remember);
    }


    public AuthenticationResult SignUp(string username, string password, string name, string email)
    {
        return new AuthenticationResult(Guid.NewGuid(),
            username,
            name,
            email,
            "pfp url goes here",
            "token goes here",
            true);
    }
}