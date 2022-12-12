using Communion.Application.Common.Interfaces.Persistence;
using Communion.Domain.CategoryAggregate;

namespace Communion.Infrastructure.Persistence;

public class CategoryRepository : ICategoryRepository
{
    private static readonly List<Category> _categories = new();
    public void Add(Category category)
    {
        _categories.Add(category);
    }

    public Category? GetCategoryById(Guid categoryId)
    {
        return _categories.Find(c => c.Id.Value == categoryId);
    }
}