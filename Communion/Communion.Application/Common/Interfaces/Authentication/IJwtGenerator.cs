using Communion.Domain.Entities;

namespace Communion.Application.Common.Interfaces.Authentication;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}