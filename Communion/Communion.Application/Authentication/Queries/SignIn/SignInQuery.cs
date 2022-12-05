using Communion.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Communion.Application.Authentication.Queries.SignIn;

public record SignInQuery(
    string Username,
    string Password,
    bool Remember) : IRequest<ErrorOr<AuthenticationResult>>;