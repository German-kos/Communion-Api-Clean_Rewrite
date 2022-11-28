namespace Communion.Application.Common.Interfaces.Authentication;

public interface IJwtGenerator
{
    string GenerateToken(Guid userId, string username, string name);
}