using Communion.Domain.Common.DomainErrors;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.CreateTopic;

public class RemoveTopicCommandHandler
            : IRequestHandler<CreateTopicCommand, ErrorOr<Category>>
{
    // Dependency Injections
    private readonly ICategoryRepository _categoryRepository;
    public RemoveTopicCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    // Handler
    public async Task<ErrorOr<Category>> Handle(CreateTopicCommand command, CancellationToken cancellationToken)
    {
        // Temporary await, remove when this method is made async
        await Task.CompletedTask;

        // Deconstruction
        var (categoryId, topicName, username) = command;

        var category = _categoryRepository.GetCategoryById(categoryId);

        if (category is null)
            return Errors.Category.CategoryNotFound;

        return category.CreateTopic(topicName, username);
    }
}