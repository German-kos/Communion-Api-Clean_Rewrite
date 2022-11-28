namespace Communion.Application.Services.Authentication;

public record AuthenticationResult
(
    Guid Id,
    string Username,
    string Name,
    string Email,
    string ProfilePicture,
    string Token,
    bool Remember
);