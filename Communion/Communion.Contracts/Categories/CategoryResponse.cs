namespace Communion.Contracts.Categories;

public record CategoryResponse(
    string Id,
    string Name,
    BannerResponse Banner,
    List<TopicResponse> Topics,
    DateTime CreationDateTime,
    DateTime UpdateDateTime,
    bool IsModified,
    string WhoModified);

public record BannerResponse(string Id,
    string PublicId,
    string Url);

public record TopicResponse(
    string Id,
    string CategoryId,
    string Name,
    DateTime CreationDateTime,
    DateTime UpdateDateTime,
    bool IsModified,
    string WhoModified);