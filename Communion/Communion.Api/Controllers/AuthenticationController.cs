using Communion.Api.Common.BaseApi;
using Communion.Application.Services.Authentication;
using Communion.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Communion.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : BaseApiController
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
            _ => Problem(statusCode: StatusCodes.Status409Conflict, title: "Something already exists")
        );

    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                        authResult.User.Id,
                        authResult.User.Username,
                        authResult.User.Name,
                        authResult.User.Email,
                        authResult.User.ProfilePicture,
                        authResult.Token,
                        authResult.Remember);
    }

    [HttpPost("sign-in")]
    public IActionResult SignIn([FromForm] SignInRequest request)
    {
        // Deconstruction
        var (username, password, remember) = request;

        var signInResult = _auth.SignIn(
            username,
            password,
            remember);


        var authResult = signInResult;
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Username,
            authResult.User.Name,
            authResult.User.Email,
            authResult.User.ProfilePicture,
            authResult.Token,
            authResult.Remember);

        return Ok(response);


        return Problem(statusCode: StatusCodes.Status409Conflict, title: "sign in problem");
    }
}