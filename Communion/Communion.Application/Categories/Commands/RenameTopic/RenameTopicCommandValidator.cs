using Communion.Domain.Constants;
using FluentValidation;

namespace Communion.Application.Categories.Commands.RenameTopic;

public class RenameTopicCommandValidator : AbstractValidator<RenameTopicCommand>
{
    public RenameTopicCommandValidator()
    {
        // CategoryId must be provided
        RuleFor(r => r.CategoryId).NotEmpty();

        // TopicId must be provided
        RuleFor(r => r.TopicId).NotEmpty();

        // Username must be provided
        RuleFor(r => r.Username).NotEmpty();

        RuleFor(r => r.NewTopicName)
            .NotEmpty()
            .MinimumLength(Predefined.MinimumTopicNameLength)
            .MaximumLength(Predefined.MaximumTopicNameLength);
    }
}