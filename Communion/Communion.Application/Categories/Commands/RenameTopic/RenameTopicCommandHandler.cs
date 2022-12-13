using Communion.Domain.Common.DomainErrors;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.RenameTopic;

public class RenameCategoryCommandHandler
            : IRequestHandler<RenameTopicCommand, ErrorOr<Category>>
{
    // Dependency Injections
    private readonly ICategoryRepository _categoryRepository;
    public RenameCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    // Handler
    public async Task<ErrorOr<Category>> Handle(RenameTopicCommand command, CancellationToken cancellationToken)
    {
        // Temporary await, remove when this method is made async
        await Task.CompletedTask;

        // Deconstruction
        var (CategoryId, TopicId, NewTopicName, Username) = command;

        var category = _categoryRepository.GetCategoryById(CategoryId);

        if (category is null)
            return Errors.Category.CategoryNotFound;

        var topic = category.Topics.Find(t => t.Id.Value == TopicId);

        if (topic is null)
            return Errors.Category.TopicNotFound;

        return category.RenameTopic(topic, NewTopicName, Username);
    }
}