using ErrorOr;

namespace Communion.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Category
    {
        public static Error CategoryNameExists => Error.Conflict(
            code: "Category.CategoryNameExists",
            description: "Requested category name is already in use by another category.");

        public static Error CategoryNotFound => Error.Conflict(
            code: "Category.CategoryNotFound",
            description: "Requested category does not exist.");

        public static Error TopicNotFound => Error.Conflict(
            code: "Category.TopicNotFound",
            description: "Requested topic does not exist.");

        public static Error MinimumTopicAmount => Error.Conflict(
            code: "Category.MaxTopicAmount",
            description: "Category has reached the minimum amount of topics allowed.");

        public static Error MaxTopicAmount => Error.Conflict(
            code: "Category.MaxTopicAmount",
            description: "Category has reached the maximum amount of topics allowed.");

        public static Error TopicExists => Error.Conflict(
            code: "Category.TopicExists",
            description: "Topic already exists.");
    }
}