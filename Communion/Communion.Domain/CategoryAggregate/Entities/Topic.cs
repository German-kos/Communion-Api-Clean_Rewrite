using Communion.Domain.Common.Models;
using Communion.Domain.Common.ValueObjects;

namespace Communion.Domain.CategoryAggregate.Entities;

public sealed class Topic : Entity<TopicId>
{
    // Private fields
    private string _name;
    private DateTime _updateDateTime;
    private bool _isModified;
    private string _whoModified;

    // Getters
    public string Name => _name;
    public DateTime UpdateDateTime => _updateDateTime;
    public bool IsModified => _isModified;
    public string WhoModified => _whoModified;

    // Readonly fields
    public CategoryId CategoryId { get; }
    public DateTime CreationDateTime { get; }

    // Constructor
    private Topic(
        TopicId topicId,
        CategoryId categoryId,
        string name,
        string username)
        : base(topicId)
    {
        CategoryId = categoryId;
        _name = name;
        CreationDateTime = _updateDateTime = DateTime.UtcNow;
        _whoModified = username;
    }

    // Methods
    public static Topic Create(
        CategoryId categoryId,
        string name,
        string username)
    {
        return new(
            TopicId.CreateUnique(),
            categoryId,
            name,
            username);
    }

    internal Topic Rename(
        string name,
        string username)
    {
        _name = name;
        _updateDateTime = DateTime.UtcNow;
        _isModified = true;
        _whoModified = username;

        return this;
    }
}