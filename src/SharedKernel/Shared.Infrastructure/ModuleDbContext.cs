using Microsoft.EntityFrameworkCore;
using URLShortener.Domain;

namespace Shared.Infrastructure;

public class ModuleDbContext(DbContextOptions options,
    IDomainEventDispatcher dispatcher) : DbContext(options)
{
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker
            .Entries<AggregateRoot>()
            .Select(e => e.Entity)
            .SelectMany(e => e.DomainEvents)
            .ToList();

        foreach(var entry in ChangeTracker.Entries<AggregateRoot>())
        {
            entry.Entity.ClearDomainEvents();
        }

        var result = await base.SaveChangesAsync(cancellationToken);
        if (domainEvents.Count != 0 && dispatcher != null)
            await dispatcher.Dispatch(domainEvents);

        return result;
    }
}
