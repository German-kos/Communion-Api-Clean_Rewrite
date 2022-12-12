using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.EditCategory;

public record EditCategoryCommand(
    Guid CategoryId,
    string? NewName,
    string? NewBannerPublicId,
    string? NewBannerUrl,
    string Username) : IRequest<ErrorOr<Category>>;