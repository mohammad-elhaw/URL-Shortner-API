using Shared.Application;
using Shared.Application.CQRS;
using Shared.Domain;
using Shared.Messaging;
using Shared.Messaging.Events;

namespace Redirection.Application;

public class RedirectHandler(IUrlResolver urlResolver,
    IMessageBus messageBus)
    : ICommandHandler<RedirectCommand, RedirectResult>
{
    public async Task<Result<RedirectResult>> Handle(RedirectCommand command, CancellationToken cancellationToken)
    {
        var result = await urlResolver.Resolve(command.ShortUrl);

        if (result.IsSuccess)
        {
            await messageBus.Publish("url.resolved", 
                new UrlResolvedIntegrationEvent
                (
                    command.ShortUrl,
                    result.Value,
                    command.IpAddress,
                    command.UserAgent
                ), cancellationToken);
        }

        return result.Match(
            url => Result<RedirectResult>.Success(new RedirectResult(url)),
            error => Result<RedirectResult>.Failure(error)
        );
    }
}
