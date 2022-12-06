using FluentValidation;

namespace Communion.Application.Authentication.Queries.SignIn;

public class SignInQueryValidator : AbstractValidator<SignInQuery>
{
    public SignInQueryValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .MinimumLength(4);

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(8);
    }
}