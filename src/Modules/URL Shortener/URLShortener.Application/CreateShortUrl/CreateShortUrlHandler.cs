using Shared.Application.CQRS;
using Shared.Domain;
using URLShortener.Domain;
using URLShortener.Domain.Services;

namespace URLShortener.Application.CreateShortUrl;

internal class CreateShortUrlHandler(
    IShortUrlRepository repository,
    IShortCodeGenerator generator)
    : ICommandHandler<CreateShortUrlCommand, CreateShortUrlResult>
{
    public async Task<Result<CreateShortUrlResult>> Handle(CreateShortUrlCommand command, CancellationToken cancellationToken)
    {
        string code = generator.Generate();
        var shortCodeResult = ShortUrl.Create(command.OriginalUrl, code);
        if (shortCodeResult.IsFailure)
            return Result<CreateShortUrlResult>.Failure(shortCodeResult.Error!);

        await repository.Add(shortCodeResult.Value);
        await repository.SaveChanges();

        return Result<CreateShortUrlResult>.Success(new CreateShortUrlResult(shortCodeResult.Value.ShortCode));
    }
}
