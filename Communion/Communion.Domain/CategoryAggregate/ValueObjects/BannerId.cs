using Communion.Domain.Common.Models;

namespace Communion.Domain.CategoryAggregate.ValueObjects;

public sealed class BannerId : ValueObject
{
    public Guid Value { get; }

    private BannerId(Guid value)
    {
        Value = value;
    }

    public static BannerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}