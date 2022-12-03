namespace Communion.Application.Common.Errors;
public record struct SignUpError(Dictionary<string, string> errors);