using Shared.Application;
using Shared.Application.CQRS;
using Shared.Domain;

namespace Redirection.Application;

public class RedirectHandler(IUrlResolver urlResolver)
    : ICommandHandler<RedirectCommand, RedirectResult>
{
    public async Task<Result<RedirectResult>> Handle(RedirectCommand command, CancellationToken cancellationToken)
    {
        var result = await urlResolver.Resolve(command.ShortUrl);
        
        return result.Match(
            url => Result<RedirectResult>.Success(new RedirectResult(url)),
            error => Result<RedirectResult>.Failure(error)
        );
    }
}
