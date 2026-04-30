using DotNetCore.CAP;

namespace Shared.Messaging;

public class CapMessageBus(ICapPublisher capPublisher) : IMessageBus
{
    public async Task Publish<TIntegrationEvent>(string eventName, TIntegrationEvent @event, 
        CancellationToken cancellationToken = default)
        where TIntegrationEvent : IIntegrationEvent
    {
        await capPublisher.PublishAsync(eventName, @event, cancellationToken: cancellationToken);
    }
}
