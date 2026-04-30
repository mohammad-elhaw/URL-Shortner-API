using URLShortener.Domain;

namespace Analytics.Domain;

public class Visit : AggregateRoot
{
    public string ShortCode { get; private set; }
    public DateTime VisitedAt { get; private set; }
    public string? IpAddress { get; private set; }
    public string? UserAgent { get; private set; }

    private Visit() { }

    public Visit(string shortCode, string? ipAddress, string? userAgent)
    {
        ShortCode = shortCode;
        IpAddress = ipAddress;
        UserAgent = userAgent;
        VisitedAt = DateTime.UtcNow;
    }
}
