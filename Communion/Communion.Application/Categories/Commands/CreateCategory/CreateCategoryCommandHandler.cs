using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<Category>>
{
    public async Task<ErrorOr<Category>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var (categoryName, bannerPublicId, bannerUrl, topicName, username) = command;
        // Temporary await, remove when this method is made async
        await Task.CompletedTask;

        // Upload BannerImage from command
        // Create Category
        var category = Category.Create(categoryName, bannerPublicId, bannerUrl, topicName, username);
        // Persist Category
        // Return Category
        return category;
    }
}