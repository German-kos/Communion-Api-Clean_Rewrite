using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.RenameTopic;

public record RenameTopicCommand(
    Guid CategoryId,
    Guid TopicId,
    string NewTopicName,
    string Username) : IRequest<ErrorOr<Category>>;