namespace Communion.Contracts.Categories;

public record RemoveTopicRequest(
    string CategoryId,
    string TopicId);