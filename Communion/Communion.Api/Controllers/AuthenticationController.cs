using Communion.Api.Common.BaseApi;
using Communion.Application.Common.Errors;
using Communion.Application.Services.Authentication;
using Communion.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

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

        OneOf<AuthenticationResult, SignUpError> signUpResult = _auth.SignUp(
            username,
            password,
            name,
            email);

        if (signUpResult.IsT0)
        {
            var authResult = signUpResult.AsT0;
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

        return Problem(statusCode: StatusCodes.Status409Conflict, title: string.Join(", ", signUpResult.AsT1.errors.Values));
    }

    [HttpPost("sign-in")]
    public IActionResult SignIn([FromForm] SignInRequest request)
    {
        // Deconstruction
        var (username, password, remember) = request;

        OneOf<AuthenticationResult, SignInError> signInResult = _auth.SignIn(
            username,
            password,
            remember);

        if (signInResult.IsT0)
        {
            var authResult = signInResult.AsT0;
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

        return Problem(statusCode: StatusCodes.Status409Conflict, title: signInResult.AsT1.error);
    }
}