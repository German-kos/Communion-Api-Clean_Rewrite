using Communion.Domain.Entities;

namespace Communion.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token,
    bool Remember);
