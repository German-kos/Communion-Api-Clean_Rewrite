using Communion.Application.Authentication.Commands.SignUp;
using Communion.Application.Authentication.Common;
using Communion.Application.Authentication.Queries.SignIn;
using Communion.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Communion.Api.Controllers;

[Route("api/auth")]
public class AuthenticationController : ApiController
{
    // Dependency Injections:
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    // Controllers:


    [HttpPost("sign-up")]
    public async Task<IActionResult> SignUp([FromForm] SignUpRequest request)
    {
        // Deconstruction
        var (username, password, name, email) = request;

        // VVV remove after verifying mapper works correctly VVV
        // var command = new SignUpCommand(username, password, name, email);

        var command = _mapper.Map<SignUpCommand>(request);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromForm] SignInRequest request)
    {
        // Deconstruction
        var (username, password, remember) = request;

        // VVV remove after verifying mapper works correctly VVV
        // var query = new SignInQuery(username, password, remember);

        var query = _mapper.Map<SignInQuery>(request);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);


        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }
}