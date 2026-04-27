using Shared.Application.CQRS;

namespace Redirection.Application;

public record RedirectCommand(string ShortUrl) : ICommand<RedirectResult>;