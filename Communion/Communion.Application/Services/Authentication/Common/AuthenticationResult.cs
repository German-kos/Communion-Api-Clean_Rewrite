using Communion.Domain.Entities;

namespace Communion.Application.Services.Authentication.Common;

public record AuthenticationResult
(
    User User,
    string Token,
    bool Remember
);
