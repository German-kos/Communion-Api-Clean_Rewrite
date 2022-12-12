using Communion.Domain.Common.DomainErrors;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.EditCategory;

public class EditCategoryCommandHandler
            : IRequestHandler<EditCategoryCommand, ErrorOr<Category>>
{
    // Dependency Injections
    private readonly ICategoryRepository _categoryRepository;
    public EditCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    // Handler
    public async Task<ErrorOr<Category>> Handle(EditCategoryCommand command, CancellationToken cancellationToken)
    {
        // Temporary await, remove when this method is made async
        await Task.CompletedTask;

        // Deconstruction
        var (categoryId, newName, newBannerPublicId, newBannerUrl, username) = command;

        var category = _categoryRepository.GetCategoryById(categoryId);

        if (category is null)
            return Errors.Category.CategoryNotFound;

        if (newName is not null)
        {
            if (_categoryRepository.CategoryNameExists(newName))
                return Errors.Category.CategoryNameExists;

            category.Rename(newName, username);
        }

        if (newBannerPublicId is not null
            && newBannerUrl is not null)
        {
            category.UpdateBanner(newBannerPublicId, newBannerUrl, username);
        }

        return category;
    }
}