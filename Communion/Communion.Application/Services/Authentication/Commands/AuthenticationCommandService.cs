using Communion.Application.Common.Interfaces.Authentication;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Application.Services.Authentication.Common;
using Communion.Application.Services.Password;
using Communion.Domain.Common.Errors;
using Communion.Domain.Entities;
using ErrorOr;

namespace Communion.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    // Dependency Injections:
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    public AuthenticationCommandService(IJwtGenerator jwtGenerator, IUserRepository userRepository, IPasswordService passwordService)
    {
        _passwordService = passwordService;
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
    }

    // Methods:

    public ErrorOr<AuthenticationResult> SignUp(string username, string password, string name, string email)
    {
        List<Error> errors = new();

        // Validate that the user doesn't exist.
        if (_userRepository.DoesUsernameExist(username))
            errors.Add(Errors.User.DuplicateUsername);
        // return Errors.User.DuplicateUsername;

        // Validate that the email doesn't exist.
        if (_userRepository.DoesEmailExist(email))
            errors.Add(Errors.User.DuplicateEmail);
        // return Errors.User.DuplicateEmail;

        if (errors.Count > 0)
            return errors;

        // Create the new user.
        var (hash, key) = _passwordService.EncryptPassword(password);
        // using var hmac = new HMACSHA512();
        var user = new User
        {
            Username = username,
            Name = name,
            PasswordHash = hash,
            PasswordSalt = key,
            Email = email
        };

        _userRepository.Add(user);

        var token = _jwtGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token,
            true);
    }
}