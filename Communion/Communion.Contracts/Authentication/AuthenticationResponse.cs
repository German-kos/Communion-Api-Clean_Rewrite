namespace Communion.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string Username,
    string Name,
    string Email,
    string ProfilePicture,
    string Token,
    bool Remember);