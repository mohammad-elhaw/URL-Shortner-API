using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URLShortener.Application.CreateShortUrl;

namespace URLShortener.API.CreateShortUrl;


public class CreateEndpoint(IMediator mediator)
    : BaseController
{

    [HttpPost]
    public async Task<ActionResult<CreateShortUrlResult>> CreateShortUrl(CreateShortUrlCommand command)
    {
        var result = await mediator.Send(command);
        return HandleResult(result, StatusCodes.Status201Created);
    }
}
