using Shared.Application;
using Shared.Domain;
using URLShortener.Domain;

namespace URLShortener.Infrastructure;

public class UrlResolver(IShortUrlRepository repo)
     : IUrlResolver
{
    public async Task<Result<string>> Resolve(string shortCode)
    {
        var shortUrl = await repo.GetByCode(shortCode);
        
        if (shortUrl == null)
            return Result<string>.Failure(
                new Error(
                    ErrorCodes.NotFound,
                    "Short code not found",
                    default));

        return Result<string>.Success(shortUrl.OriginalUrl);
    }
}
