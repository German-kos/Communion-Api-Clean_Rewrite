namespace Communion.Contracts.Authentication;

public record SignUpRequest(string Username,
    string Password,
    string Name,
    string Email);