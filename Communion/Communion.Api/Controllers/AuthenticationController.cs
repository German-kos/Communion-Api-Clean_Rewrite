using Communion.Api.Common.BaseApi;
using Communion.Application.Services.Authentication;
using Communion.Contracts.Authentication;
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

        var authResult = _auth.SignUp(username, password, name, email);
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Username,
            authResult.User.Name,
            authResult.User.Email,
            authResult.User.ProfilePicture,
            authResult.Token,
            authResult.Remember);

        return Ok(response);
    }

    [HttpPost("sign-in")]
    public IActionResult SignIn([FromForm] SignInRequest request)
    {
        // Deconstruction
        var (username, password, remember) = request;

        var authResult = _auth.SignIn(username, password, remember);
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Username,
            authResult.User.Name,
            authResult.User.Email,
            authResult.User.ProfilePicture,
            authResult.Token,
            authResult.Remember);

        return Ok(response);
    }
}