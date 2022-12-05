using Communion.Application.Services.Authentication.Commands;
using Communion.Application.Services.Authentication.Common;
using Communion.Application.Services.Authentication.Queries;
using Communion.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Communion.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    // Dependency Injections:
    private readonly IAuthenticationCommandService _authCommandService;
    private readonly IAuthenticationQueryService _authQueryService;
    public AuthenticationController(
        IAuthenticationCommandService authCommandService,
        IAuthenticationQueryService authQueryService)
    {
        _authCommandService = authCommandService;
        _authQueryService = authQueryService;
    }


    // Controllers:


    [HttpPost("sign-up")]
    public IActionResult SignUp([FromForm] SignUpRequest request)
    {
        // Deconstruction
        var (username, password, name, email) = request;

        ErrorOr<AuthenticationResult> authResult = _authCommandService.SignUp(
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

        ErrorOr<AuthenticationResult> authResult = _authQueryService.SignIn(
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