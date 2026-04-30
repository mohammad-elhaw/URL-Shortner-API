namespace Shared.Messaging.Events;

public record UrlResolvedIntegrationEvent(
    string ShortUrl, 
    string OriginalUrl,
    string? IpAddress,
    string? UserAgent) 
    : IIntegrationEvent;