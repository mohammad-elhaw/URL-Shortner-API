namespace URLShortener.Domain;

public class DomainEvent
{
    public Guid Id => Guid.NewGuid();
    public DateTime OccuredOn => DateTime.UtcNow;
    public string EventName => GetType().AssemblyQualifiedName!;
}
