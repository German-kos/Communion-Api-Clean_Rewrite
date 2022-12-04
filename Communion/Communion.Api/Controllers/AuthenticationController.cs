using Communion.Api.Common.BaseApi;
using Communion.Application.Common.Errors;
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

        var signUpResult = _auth.SignUp(
            username,
            password,
            name,
            email);

        if (signUpResult.IsSuccess)
            return Ok(MapAuthResult(signUpResult.Value));

        var firstError = signUpResult.Errors[0];

        if (firstError is SignUpError)
            return Problem(statusCode: StatusCodes.Status409Conflict, detail: "sign up problem");

        return Problem();


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