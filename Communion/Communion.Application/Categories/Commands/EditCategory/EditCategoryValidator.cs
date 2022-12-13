using Communion.Domain.Constants;
using FluentValidation;

namespace Communion.Application.Categories.Commands.EditCategory;

public class CreateTopicCommandValidator : AbstractValidator<EditCategoryCommand>
{
    public CreateTopicCommandValidator()
    {
        // CategoryId must be provided
        RuleFor(r => r.CategoryId).NotEmpty();

        // When NewBannerPublicId and NewBannerUrl are empty,
        // NewName must be provided
        When(r =>
            string.IsNullOrEmpty(r.NewBannerPublicId)
            && string.IsNullOrEmpty(r.NewBannerUrl),
            () =>
            {
                RuleFor(r => r.NewName)
                    .NotEmpty()
                    .MinimumLength(Predefined.MinimumCategoryNameLength)
                    .MaximumLength(Predefined.MaximumCategoryNameLength);
            });

        // When NewName is empty
        // NewBannerPublicId and NewBannerUrl must be provided
        When(r =>
            string.IsNullOrEmpty(r.NewName),
            () =>
            {
                RuleFor(r => r.NewBannerPublicId).NotEmpty();
                RuleFor(r => r.NewBannerUrl).NotEmpty();
            });

        When(r =>
            !string.IsNullOrEmpty(r.NewName)
            && !string.IsNullOrEmpty(r.NewBannerPublicId)
            && !string.IsNullOrEmpty(r.NewBannerUrl),
            () =>
            {
                RuleFor(r => r.NewName)
                    .NotEmpty()
                    .MinimumLength(Predefined.MinimumCategoryNameLength)
                    .MaximumLength(Predefined.MaximumCategoryNameLength);
            });
    }
}