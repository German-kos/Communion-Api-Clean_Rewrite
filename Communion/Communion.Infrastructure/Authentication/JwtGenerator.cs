using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Communion.Application.Common.Interfaces.Authentication;
using Communion.Application.Common.Interfaces.Services;
using Communion.Domain.Entities;
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


    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.Secret)),
                SecurityAlgorithms.HmacSha256
            );


        var claims = new List<Claim>
        {
        new Claim(JwtRegisteredClaimNames.NameId, user.Username),
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Name, user.Name),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: _time.UtcNow.AddDays(_options.ExpiryDays),
        signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}