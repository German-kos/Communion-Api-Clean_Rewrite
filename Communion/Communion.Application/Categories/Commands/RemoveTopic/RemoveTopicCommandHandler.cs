using Communion.Domain.Common.DomainErrors;
using Communion.Application.Common.Interfaces.Persistence;
using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;
using Communion.Application.Categories.Commands.RemoveTopic;

namespace Communion.Application.Categories.Commands.RemoveTopic;

public class RemoveTopicCommandHandler
            : IRequestHandler<RemoveTopicCommand, ErrorOr<Category>>
{
    // Dependency Injections
    private readonly ICategoryRepository _categoryRepository;
    public RemoveTopicCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    // Handler
    public async Task<ErrorOr<Category>> Handle(RemoveTopicCommand command, CancellationToken cancellationToken)
    {
        // Temporary await, remove when this method is made async
        await Task.CompletedTask;

        // Deconstruction
        var (CategoryId, TopicId, Username) = command;

        var category = _categoryRepository.GetCategoryById(CategoryId);

        if (category is null)
            return Errors.Category.CategoryNotFound;

        var topic = category.Topics.Find(t => t.Id.Value == TopicId);
        if (topic is null)
            return Errors.Category.TopicNotFound;

        return category.RemoveTopic(topic, Username);
    }
}