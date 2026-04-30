namespace Analytics.Domain;

public interface IVisitRepository
{
    Task AddAsync(Visit entity);
    Task<int> GetTotalClicks(string shortCode);
    Task<int> GetClicksToday(string shortCode);
    Task SaveChange();
}
