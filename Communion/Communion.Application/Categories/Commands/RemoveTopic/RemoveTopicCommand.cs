using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.RemoveTopic;

public record RemoveTopicCommand(
    Guid CategoryId,
    Guid TopicId,
    string Username) : IRequest<ErrorOr<Category>>;