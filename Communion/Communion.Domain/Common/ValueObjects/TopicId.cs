using Communion.Domain.Common.Models;

namespace Communion.Domain.Common.ValueObjects;

public sealed class TopicId : ValueObject
{
    public Guid Value { get; }

    private TopicId(Guid value)
    {
        Value = value;
    }

    public static TopicId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}