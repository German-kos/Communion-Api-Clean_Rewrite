using Communion.Domain.CategoryAggregate;

namespace Communion.Application.Common.Interfaces.Persistence;

public interface ICategoryRepository
{
    void Add(Category category);
}