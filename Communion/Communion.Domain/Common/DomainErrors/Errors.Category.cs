using ErrorOr;

namespace Communion.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Category
    {
        public static Error TopicNotFound => Error.Conflict(
            code: "Category.TopicNotFound",
            description: "This topic does not exist.");

        public static Error MaxTopicAmount => Error.Conflict(
            code: "Category.MaxTopicAmount",
            description: "Category has reached the maximum amount of topics allowed.");

        public static Error TopicExists => Error.Conflict(
            code: "Category.TopicExists",
            description: "Topic already exists.");
    }
}