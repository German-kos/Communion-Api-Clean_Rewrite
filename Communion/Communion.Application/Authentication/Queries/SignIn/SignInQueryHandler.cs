using Communion.Application.Authentication.Common;
using Communion.Application.Common.Interfaces.Authentication;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Application.Services.Password;
using Communion.Domain.Common.Errors;
using Communion.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Communion.Application.Authentication.Queries.SignIn;

public class SignInQueryHandler :
IRequestHandler<SignInQuery, ErrorOr<AuthenticationResult>>
{
    // Dependency Injections
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    public SignInQueryHandler(
        IJwtGenerator jwtGenerator,
        IUserRepository userRepository,
        IPasswordService passwordService)
    {
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
        _passwordService = passwordService;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(SignInQuery query, CancellationToken cancellationToken)
    {
        // Temporary await, remove when this method is made async
        await Task.CompletedTask;

        // Deconstruction
        var (username, password, remember) = query;

        // Validate that the user exists.
        if (_userRepository.GetByUsername(username) is not User user)
            return Errors.Authentication.InvalidCredentials;

        // Validate that passwords match
        if (!_passwordService.PasswordsMatch(password, user))
            return Errors.Authentication.InvalidCredentials;

        var token = _jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token,
            remember);
    }
}
