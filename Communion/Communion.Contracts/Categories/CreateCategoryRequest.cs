using Microsoft.AspNetCore.Http;

namespace Communion.Contracts.Categories;

public record CreateCategoryRequest(
    string CategoryName,
    IFormFile BannerImage,
    string TopicName);