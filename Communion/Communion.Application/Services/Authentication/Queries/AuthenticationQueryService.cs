using Communion.Application.Common.Interfaces.Authentication;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Application.Services.Authentication.Common;
using Communion.Application.Services.Password;
using Communion.Domain.Common.Errors;
using Communion.Domain.Entities;
using ErrorOr;

namespace Communion.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    // Dependency Injections:
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    public AuthenticationQueryService(IJwtGenerator jwtGenerator, IUserRepository userRepository, IPasswordService passwordService)
    {
        _passwordService = passwordService;
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
    }

    // Methods:

    public ErrorOr<AuthenticationResult> SignIn(string username, string password, bool remember)
    {
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

    public bool Equals(AuthenticationQueryService other)
    {
        throw new NotImplementedException();
    }
}