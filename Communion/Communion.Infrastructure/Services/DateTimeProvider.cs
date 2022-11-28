using Communion.Application.Common.Interfaces.Services;

namespace Communion.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}