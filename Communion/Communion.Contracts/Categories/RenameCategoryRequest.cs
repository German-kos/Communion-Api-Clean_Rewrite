namespace Communion.Contracts.Categories;

public record RenameCategoryRequest(
    string CategoryId,
    string NewName);