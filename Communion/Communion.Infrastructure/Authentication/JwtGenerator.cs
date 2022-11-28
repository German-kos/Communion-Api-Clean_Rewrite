using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Communion.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace Communion.Infrastructure.Authentication;

public class JwtGenerator : IJwtGenerator
{
    public string GenerateToken(Guid userId, string username)
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
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: "Communion",
            expires: DateTime.Now.AddDays(1),
            claims: claims,
        signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}