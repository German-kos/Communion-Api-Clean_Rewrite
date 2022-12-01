using System.Security.Cryptography;
using System.Text;
using Communion.Application.Common.Interfaces.Authentication;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Domain.Entities;

namespace Communion.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    // Dependency Injections:
    private readonly IJwtGenerator _jwt;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtGenerator jwt, IUserRepository userRepository)
    {
        _jwt = jwt;
        _userRepository = userRepository;
    }


    // Methods:


    public AuthenticationResult SignIn(string username, string password, bool remember)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            username,
            "name goes here",
            "email goes here",
            "pfp url goes here",
            "token goes here",
            remember);
    }


    public AuthenticationResult SignUp(string username, string password, string name, string email)
    {
        // write check for if user/email already exist
        if (_userRepository.GetByUsername(username) is not null)
            throw new Exception("This username is already in use.");


        // write creation of user in the database
        using var hmac = new HMACSHA512();
        var user = new User
        {
            Username = username,
            Name = name,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key,
            Email = email
        };

        var token = _jwt.GenerateToken(user.Id, username, name);

        return new AuthenticationResult(
            user.Id,
            username,
            name,
            email,
            "pfp url goes here",
            token,
            true);
    }
}