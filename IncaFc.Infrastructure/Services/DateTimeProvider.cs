using IncaFc.Application.Common.Interfaces.Services;

namespace IncaFc.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}