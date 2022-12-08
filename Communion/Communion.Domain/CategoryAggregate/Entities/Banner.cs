using Communion.Domain.CategoryAggregate.ValueObjects;
using Communion.Domain.Common.Models;

namespace Communion.Domain.Category.Entities;

public sealed class Banner : Entity<BannerId>
{
    public string PublicId { get; }
    public string Url { get; }

    private Banner(
        BannerId bannerId,
        string publicId,
        string url)
        : base(bannerId)
    {
        PublicId = publicId;
        Url = url;
    }

    public static Banner Create(
        string publicId,
        string url)
    {
        return new(
            BannerId.CreateUnique(),
            publicId,
            url);
    }
}