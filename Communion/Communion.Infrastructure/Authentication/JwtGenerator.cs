using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Communion.Application.Common.Interfaces.Authentication;
using Communion.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Communion.Infrastructure.Authentication;

public class JwtGenerator : IJwtGenerator
{
    // Dependency Injections:
    private readonly IDateTimeProvider _time;
    private readonly JwtSettings _options;
    public JwtGenerator(IDateTimeProvider time, IOptions<JwtSettings> options)
    {
        _options = options.Value;
        _time = time;
    }


    // Methods:


    public string GenerateToken(Guid userId, string username, string name)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.Secret)),
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
            issuer: _options.Issuer,
            audience: _options.Audience,
            expires: _time.UtcNow.AddDays(_options.ExpiryDays),
            claims: claims,
        signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}