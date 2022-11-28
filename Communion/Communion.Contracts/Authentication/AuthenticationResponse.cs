namespace Communion.Contracts.Authentication;

public record AuthenticationResponse
(
    Guid Id,
    string Username,
    string Name,
    string Token,
    string ProfilePicture,
    bool Remember
);