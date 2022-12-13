using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.CreateTopic;

public record CreateTopicCommand(
    Guid CategoryId,
    string TopicName,
    string Username) : IRequest<ErrorOr<Category>>;