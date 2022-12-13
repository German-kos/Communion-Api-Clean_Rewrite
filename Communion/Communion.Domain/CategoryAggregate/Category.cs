using Communion.Domain.Category.Entities;
using Communion.Domain.CategoryAggregate.Entities;
using Communion.Domain.Common.DomainErrors;
using Communion.Domain.Common.Models;
using Communion.Domain.Common.ValueObjects;
using Communion.Domain.Constants;
using ErrorOr;

namespace Communion.Domain.CategoryAggregate;

public sealed class Category : AggregateRoot<CategoryId>
{
    // Private fields
    private string _name;
    private Banner _banner;
    private DateTime _updateDateTime;
    private bool _isModified;
    private string _whoModified;

    // Getters
    public string Name => _name;
    public Banner Banner => _banner;
    public DateTime UpdateDateTime => _updateDateTime;
    public bool IsModified => _isModified;
    public string WhoModified => _whoModified;

    // Readonly fields
    public List<Topic> Topics { get; }
    public DateTime CreationDateTime { get; }

    // Constructor
    private Category(
        CategoryId categoryId,
        string name,
        Banner banner,
        Topic topic,
        string username)
        : base(categoryId)
    {
        _name = name;
        _banner = banner;
        Topics = new() { topic };
        // _topics.Add(topic);
        CreationDateTime = _updateDateTime = DateTime.UtcNow;
        _whoModified = username;
    }

    // Methods
    public static Category Create(
        string categoryName,
        string bannerPublicId,
        string bannerUrl,
        string topicName,
        string username)
    {
        var categoryId = CategoryId.CreateUnique();

        return new(
            categoryId,
            categoryName,
            Banner.Create(bannerPublicId, bannerUrl),
            Topic.Create(categoryId, topicName, username),
            username);
    }

    public Category Rename(
        string name,
        string username)
    {
        _name = name;
        LogUpdate(username);

        return this;
    }

    public Category UpdateBanner(string bannerPublicId, string bannerUrl, string username)
    {
        _banner = Banner.Create(bannerPublicId, bannerUrl);

        LogUpdate(username);

        return this;
    }

    public ErrorOr<Category> CreateTopic(
        string name,
        string username)
    {
        if (Topics.Count >= Predefined.MaxTopicAmount)
            return Errors.Category.MaxTopicAmount;

        bool topicExists = Topics.Any(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase));
        if (topicExists)
            return Errors.Category.TopicExists;

        Topics.Add(
            Topic.Create(
                Id,
                name,
                username));

        LogUpdate(username);

        return this;
    }

    public ErrorOr<Category> RenameTopic(
        Topic target,
        string name,
        string username)
    {
        var topic = Topics.Find(t => t == target);

        if (topic is null)
            return Errors.Category.TopicNotFound;

        topic.Rename(name, username);

        return this;
    }

    public ErrorOr<Category> RemoveTopic(
    Topic target,
    string username)
    {
        bool topicRemoved = Topics.Remove(target);

        if (!topicRemoved)
            return Errors.Category.TopicNotFound;

        LogUpdate(username);

        return this;
    }

    // Private methods
    private void LogUpdate(string username)
    {
        _updateDateTime = DateTime.UtcNow;
        _isModified = true;
        _whoModified = username;
    }
}