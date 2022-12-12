using Microsoft.AspNetCore.Http;

namespace Communion.Contracts.Categories;

public record EditCategoryRequest(
    string CategoryId,
    string? NewName,
    IFormFile? NewBannerImage);