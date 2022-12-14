using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(
    string CategoryName,
    string BannerPublicId,
    string BannerUrl,
    string TopicName,
    string Username) : IRequest<ErrorOr<Category>>;