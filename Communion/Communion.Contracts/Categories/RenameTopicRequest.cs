namespace Communion.Contracts.Categories;

public record RenameTopicRequest(
    string CategoryId,
    string TopicId,
    string NewTopicName);