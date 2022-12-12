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

    public bool CategoryNameExists(string categoryName)
    {
        return _categories.Any(c => string.Equals(c.Name, categoryName, StringComparison.OrdinalIgnoreCase));
    }

    public Category? GetCategoryById(Guid categoryId)
    {
        return _categories.Find(c => c.Id.Value == categoryId);
    }
}