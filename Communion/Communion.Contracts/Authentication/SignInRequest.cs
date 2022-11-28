namespace Communion.Contracts.Authentication;

public record SignInRequest
(
    string Username,
    string Password,
    bool Remember
);