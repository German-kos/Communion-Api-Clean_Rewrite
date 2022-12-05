using Communion.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Communion.Application.Authentication.Commands.SignUp;

public record SignUpCommand(
    string Username,
    string Password,
    string Name,
    string Email) : IRequest<ErrorOr<AuthenticationResult>>;