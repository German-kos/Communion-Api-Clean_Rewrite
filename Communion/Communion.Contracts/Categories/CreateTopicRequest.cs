namespace Communion.Contracts.Categories;

public record CreateTopicRequest(
    string CategoryId,
    string TopicName);