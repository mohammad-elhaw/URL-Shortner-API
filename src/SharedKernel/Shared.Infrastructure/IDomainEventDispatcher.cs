using URLShortener.Domain;

namespace Shared.Infrastructure;

public interface IDomainEventDispatcher
{
    Task Dispatch(IEnumerable<DomainEvent> domainEvents);
}