using Analytics.Domain;
using DotNetCore.CAP;
using Shared.Messaging.Events;

namespace Analytics.Application;

public class UrlResolvedIntegrationEventHandler(
    IVisitRepository repository)
    : ICapSubscribe
{
    [CapSubscribe("url.resolved")]
    public async Task Handle(UrlResolvedIntegrationEvent @event, CancellationToken cancellationToken)
    {
        var visit = new Visit(
            @event.ShortUrl,
            @event.IpAddress,
            @event.UserAgent
        );
        await repository.AddAsync(visit);
        await repository.SaveChange();
    }
}
