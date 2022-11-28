using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Communion.Application.Common.Interfaces.Authentication;
using Communion.Application.Common.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace Communion.Infrastructure.Authentication;

public class JwtGenerator : IJwtGenerator
{
    // Dependency Injections:
    private readonly IDateTimeProvider _time;
    public JwtGenerator(IDateTimeProvider time)
    {
        _time = time;
    }


    // Methods:


    public string GenerateToken(Guid userId, string username, string name)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("dont-tell-anyone-about-this-key")),
                SecurityAlgorithms.HmacSha256
            );


        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
        new Claim(JwtRegisteredClaimNames.NameId, username),
        new Claim(JwtRegisteredClaimNames.Name, name),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: "Communion",
            expires: _time.UtcNow.AddDays(7),
            claims: claims,
        signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}