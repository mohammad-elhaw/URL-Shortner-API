namespace URLShortener.Domain;

public interface IShortUrlRepository
{
    Task Add(ShortUrl shortUrl);
    Task<ShortUrl?> GetByCode(string code);
    Task SaveChanges();
}