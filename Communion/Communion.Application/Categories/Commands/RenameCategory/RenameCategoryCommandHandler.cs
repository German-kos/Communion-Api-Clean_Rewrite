using Communion.Domain.Common.DomainErrors;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.RenameCategory;

public class RenameCategoryCommandHandler
            : IRequestHandler<RenameCategoryCommand, ErrorOr<Category>>
{
    // Dependency Injections
    private readonly ICategoryRepository _categoryRepository;
    public RenameCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    // Handler
    public async Task<ErrorOr<Category>> Handle(
        RenameCategoryCommand command,
        CancellationToken cancellationToken)
    {
        // Temporary await, remove when this method is made async
        await Task.CompletedTask;

        // Deconstruction
        var (categoryId, newName, username) = command;

        var category = _categoryRepository.GetCategoryById(categoryId);

        if (category is null)
            return Errors.Category.CategoryNotFound;

        return category.Rename(newName, username);
    }
}
