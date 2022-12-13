using FluentValidation;

namespace Communion.Application.Categories.Commands.RemoveTopic;

public class RemoveTopicCommandValidator : AbstractValidator<RemoveTopicCommand>
{
    public RemoveTopicCommandValidator()
    {
        // CategoryId must be provided
        RuleFor(r => r.CategoryId).NotEmpty();

        // TopicId must be provided
        RuleFor(r => r.TopicId).NotEmpty();

        // Username must be provided
        RuleFor(r => r.Username).NotEmpty();
    }
}