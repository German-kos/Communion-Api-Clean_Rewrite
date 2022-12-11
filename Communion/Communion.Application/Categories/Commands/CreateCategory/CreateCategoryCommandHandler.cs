using System.Data;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Application.Common.Interfaces.Services;
using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<Category>>
{
    // Dependency Injections
    private readonly ICategoryRepository _categoryRepository;
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    // Handler
    public async Task<ErrorOr<Category>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        // Deconstruction
        var (categoryName, BannerPublicId, BannerUrl, topicName, username) = command;

        // Temporary await, remove when this method is made async
        await Task.CompletedTask;

        // Create Category
        var category = Category.Create(categoryName, BannerPublicId, BannerUrl, topicName, username);

        // Persist Category
        _categoryRepository.Add(category);

        // Return Category
        return category;
    }
}