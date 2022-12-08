using ErrorOr;

namespace Communion.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class General
    {
        public static Error EmptyField => Error.Conflict(
            code: "General.EmptyField",
            description: "At least one mandatory field value has not been provided.");
    }
}