using Shared.Application.CQRS;

namespace Redirection.Application;

public record RedirectCommand(
    string ShortUrl,
    string? IpAddress,
    string? UserAgent) : ICommand<RedirectResult>;