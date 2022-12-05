using Communion.Application.Authentication.Commands.SignUp;
using Communion.Application.Authentication.Common;
using Communion.Application.Authentication.Queries.SignIn;
using Communion.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Communion.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    // Dependency Injections:
    private readonly ISender _mediator;

    protected AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }


    // Controllers:


    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromForm] SignUpRequest request)
    {
        // Deconstruction
        var (username, password, name, email) = request;

        var command = new SignUpCommand(username, password, name, email);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromForm] SignInRequest request)
    {
        // Deconstruction
        var (username, password, remember) = request;

        var query = new SignInQuery(username, password, remember);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);


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