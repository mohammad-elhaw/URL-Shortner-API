using URLShortener.Domain;
using URLShortener.Infrastructure.Database;

namespace URLShortener.Infrastructure;

public class ShortUrlRepository(ShortUrlDbContext context)
    : IShortUrlRepository
{
    public async Task Add(ShortUrl shortUrl)
        => await context.ShortUrls.AddAsync(shortUrl);

    public async Task<ShortUrl?> GetByCode(string code)
        => await context.ShortUrls.FindAsync(code);

    public async Task SaveChanges() => await context.SaveChangesAsync();
}
