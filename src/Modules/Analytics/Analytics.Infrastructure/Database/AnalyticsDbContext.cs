using Analytics.Domain;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure;
using URLShortener.Domain;

namespace Analytics.Infrastructure.Database;

public class AnalyticsDbContext(DbContextOptions<AnalyticsDbContext> options, IDomainEventDispatcher dispatcher)
    : ModuleDbContext(options, dispatcher)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("analytics");
        modelBuilder.Ignore<DomainEvent>();

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ShortCode).IsRequired();
            entity.Property(e => e.VisitedAt)
                .IsRequired();
            entity.HasIndex(e => e.ShortCode);
            entity.HasIndex(e => e.VisitedAt);
        });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Visit> Visits { get; set; } = null!;
}
