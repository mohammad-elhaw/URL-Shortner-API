using Shared.Application.CQRS;

namespace URLShortener.Application.CreateShortUrl;

public record CreateShortUrlCommand(string OriginalUrl) : ICommand<CreateShortUrlResult>;