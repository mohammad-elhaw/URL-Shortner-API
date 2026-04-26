using Shared.Domain;

namespace URLShortener.Domain;

public class ShortUrl : AggregateRoot
{
    public string OriginalUrl { get; private set; }
    public string ShortCode { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int ClickCount { get; private set; }
    private ShortUrl() { } // EF
    private ShortUrl(string originalUrl, string shortCode)
    {
        OriginalUrl = originalUrl;
        ShortCode = shortCode;
        CreatedAt = DateTime.UtcNow;
        ClickCount = 0;
    }

    public static Result<ShortUrl> Create(string originalUrl, string shortCode)
    {
        if(string.IsNullOrWhiteSpace(originalUrl))
            return Result<ShortUrl>.Failure(
                new Error(
                    ErrorCodes.BadRequest, 
                    "Original URL cannot be empty.",
                    default));

        if(string.IsNullOrWhiteSpace(shortCode))
            return Result<ShortUrl>.Failure(
                new Error(
                    ErrorCodes.BadRequest, 
                    "Short code cannot be empty.",
                    default));

        return Result<ShortUrl>.Success(new(originalUrl, shortCode));
    }

    public void IncrementClickCount()
        => ClickCount++;
}
