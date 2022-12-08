using ErrorOr;

namespace Communion.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCred",
            description: "Invalid credentials.");
    }
}