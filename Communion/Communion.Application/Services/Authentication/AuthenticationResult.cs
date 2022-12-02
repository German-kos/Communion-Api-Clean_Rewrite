using Communion.Domain.Entities;

namespace Communion.Application.Services.Authentication;

public record AuthenticationResult
(
    User User,
    string Token,
    bool Remember
);