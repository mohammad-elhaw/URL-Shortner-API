namespace Shared.Messaging;

public interface IMessageBus
{
    Task Publish<TIntegrationEvent>(string eventName, TIntegrationEvent @event,
        CancellationToken cancellationToken = default)
        where TIntegrationEvent : IIntegrationEvent;
}
