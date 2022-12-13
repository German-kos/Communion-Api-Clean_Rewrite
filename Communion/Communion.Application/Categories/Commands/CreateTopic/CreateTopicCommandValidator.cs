using Communion.Domain.Constants;
using FluentValidation;

namespace Communion.Application.Categories.Commands.CreateTopic;
public class CreateTopicCommandValidator : AbstractValidator<CreateTopicCommand>
{
    public CreateTopicCommandValidator()
    {
        // CategoryId must be provided
        RuleFor(r => r.CategoryId).NotEmpty();

        // TopicName must be provided
        RuleFor(r => r.TopicName)
            .NotEmpty()
            .MinimumLength(Predefined.MinimumTopicNameLength)
            .MaximumLength(Predefined.MaximumTopicNameLength);
    }
}