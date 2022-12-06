using FluentValidation;

namespace Communion.Application.Authentication.Commands.SignUp;

public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(u => u.Username).NotEmpty().MinimumLength(4);
        RuleFor(u => u.Password).NotEmpty().MinimumLength(8);
        RuleFor(u => u.Name).NotEmpty();
        RuleFor(u => u.Email).NotEmpty();
    }
}