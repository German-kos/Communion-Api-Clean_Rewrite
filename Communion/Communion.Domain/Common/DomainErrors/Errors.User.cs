using ErrorOr;

namespace Communion.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateUsername => Error.Conflict(
            code: "User.DuplicateUsername",
            description: "Username is already in use.");

        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use.");
    }
}