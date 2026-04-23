namespace URLShortener.Domain;

public class AggregateRoot : Entity<Guid>
{  
    protected AggregateRoot(Guid id) : base(id) { }
    protected AggregateRoot() : base() { }

    protected void RaiseDomainEvent(DomainEvent domainEvent)
        => AddDomainEvent(domainEvent);
}
