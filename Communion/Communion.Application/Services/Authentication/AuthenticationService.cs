using System.Security.Cryptography;
using System.Text;
using Communion.Application.Common.Errors;
using Communion.Application.Common.Interfaces.Authentication;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Domain.Entities;
using OneOf;

namespace Communion.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    // Dependency Injections:
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtGenerator jwtGenerator, IUserRepository userRepository)
    {
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
    }


    // Methods:


    public OneOf<AuthenticationResult, SignInError> SignIn(string username, string password, bool remember)
    {
        // Validate that the user exists.
        if (_userRepository.GetByUsername(username) is not User user)
            return new SignInError("User does not exist.");

        // Validate that passwords match
        if (!PasswordsMatch(password, user))
            return new SignInError("Wrong password.");

        var token = _jwtGenerator.GenerateToken(user);

        string? pfp = user.ProfilePicture;
        if (pfp is null)
            pfp = "No pfp";

        return new AuthenticationResult(
            user,
            token,
            remember);
    }


    public OneOf<AuthenticationResult, SignUpError> SignUp(string username, string password, string name, string email)
    {
        Dictionary<string, string> errors = new();

        // Validate that the user doesn't exist.
        if (_userRepository.DoesUsernameExist(username))
            errors.Add("Username", "Username already exists.");

        // Validate that the email doesn't exist.
        if (_userRepository.DoesEmailExist(email))
            errors.Add("Email", "Email already exists.");

        if (errors.Count > 0)
            return new SignUpError(errors);

        // Create the new user.
        using var hmac = new HMACSHA512();
        var user = new User
        {
            Username = username,
            Name = name,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key,
            Email = email
        };

        _userRepository.Add(user);

        var token = _jwtGenerator.GenerateToken(user);


        return new AuthenticationResult(
            user,
            token,
            true);
    }


    private bool PasswordsMatch(string password, User user)
    {
        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        for (int i = 0; i < computedHash.Length; i++)
            if (computedHash[i] != user.PasswordHash[i])
                return false;

        return true;
    }
}