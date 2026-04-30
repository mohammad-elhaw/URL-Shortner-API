using Analytics.Domain;
using Analytics.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Analytics.Infrastructure;

public class VisitRepository(AnalyticsDbContext context)
    : IVisitRepository
{
    public async Task AddAsync(Visit entity)
        => await context.Visits.AddAsync(entity);

    public async Task<int> GetClicksToday(string shortCode)
        => await context.Visits
            .CountAsync(x => x.ShortCode == shortCode && x.VisitedAt >= DateTime.UtcNow.Date);

    public Task<int> GetTotalClicks(string shortCode)
        => context.Visits
            .CountAsync(x => x.ShortCode == shortCode);

    public async Task SaveChange()
        => await context.SaveChangesAsync();
}
