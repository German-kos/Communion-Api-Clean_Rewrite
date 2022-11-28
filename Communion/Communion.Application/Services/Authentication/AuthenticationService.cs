using Communion.Application.Common.Interfaces.Authentication;

namespace Communion.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    // Dependency Injections:
    private readonly IJwtGenerator _jwt;
    public AuthenticationService(IJwtGenerator jwt)
    {
        _jwt = jwt;
    }


    // Methods:


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
        // write check for if user/email already exist

        // write creation of user in the database

        Guid userId = Guid.NewGuid();

        var token = _jwt.GenerateToken(userId, username);

        return new AuthenticationResult(
            userId,
            username,
            name,
            email,
            "pfp url goes here",
            token,
            true);
    }
}