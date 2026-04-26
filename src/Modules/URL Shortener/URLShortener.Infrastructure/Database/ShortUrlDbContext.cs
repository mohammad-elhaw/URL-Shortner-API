using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure;
using URLShortener.Domain;

namespace URLShortener.Infrastructure.Database;

public class ShortUrlDbContext(
    DbContextOptions<ShortUrlDbContext> options,
    IDomainEventDispatcher dispatcher)
    : ModuleDbContext(options, dispatcher)
{
    public DbSet<ShortUrl> ShortUrls { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("url_shortener");
        modelBuilder.Ignore<DomainEvent>();

        modelBuilder.Entity<ShortUrl>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ShortCode).IsRequired().HasMaxLength(100);
            entity.Property(e => e.OriginalUrl).IsRequired().HasMaxLength(2048);
            entity.Property(e => e.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();
        });
        base.OnModelCreating(modelBuilder);
    }
}
