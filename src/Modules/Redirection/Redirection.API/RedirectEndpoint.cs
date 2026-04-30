using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redirection.Application;

namespace Redirection.API;

public class RedirectEndpoint(IMediator mediator)
    : BaseController
{
    [HttpGet("{code}")]
    public async Task<ActionResult<Application.RedirectResult>> RedirectCode([FromRoute] string code)
    {
        var result = await mediator.Send(new RedirectCommand(code));
        return HandleResult(result, StatusCodes.Status301MovedPermanently);
    }
}
