using MediatR;
using Shared.Application;
using URLShortener.Domain;

namespace Shared.Infrastructure;

public class DomainEventDispatcher(IMediator mediator)
    : IDomainEventDispatcher
{
    public async Task Dispatch(IEnumerable<DomainEvent> domainEvents)
    {
        foreach(var domainEvent in domainEvents)
        {
            var notificationType =  typeof(DomainEventNotification<>)
                .MakeGenericType(domainEvent.GetType());

            var notification = (INotification)Activator.CreateInstance(notificationType, domainEvent)!;

            await mediator.Publish(notification);
        }
    }
}
