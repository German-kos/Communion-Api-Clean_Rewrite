using Communion.Application.Services.Authentication;
using Communion.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Communion.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    // Dependency Injections:
    private readonly IAuthenticationService _auth;
    public AuthenticationController(IAuthenticationService auth)
    {
        _auth = auth;
    }


    // Controllers:


    [HttpPost("sign-up")]
    public IActionResult SignUp([FromForm] SignUpRequest request)
    {
        // Deconstruction
        var (username, password, name, email) = request;

        ErrorOr<AuthenticationResult> authResult = _auth.SignUp(
            username,
            password,
            name,
            email);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));

    }


    [HttpPost("sign-in")]
    public IActionResult SignIn([FromForm] SignInRequest request)
    {
        // Deconstruction
        var (username, password, remember) = request;

        ErrorOr<AuthenticationResult> authResult = _auth.SignIn(
           username,
           password,
           remember);


        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        // Deconstruction
        var (id, username, name, email, profilePicture) = authResult.User;
        var (token, remember) = (authResult.Token, authResult.Remember);

        return new AuthenticationResponse(
            id,
            username,
            name,
            email,
            profilePicture,
            token,
            remember);
    }
}