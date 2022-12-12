using Communion.Domain.CategoryAggregate;
using ErrorOr;
using MediatR;

namespace Communion.Application.Categories.Commands.RenameCategory;

public record RenameCategoryCommand(
    Guid CategoryId,
    string NewName,
    string Username) : IRequest<ErrorOr<Category>>;