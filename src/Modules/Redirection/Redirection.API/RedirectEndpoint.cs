using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redirection.Application;

namespace Redirection.API;

public class RedirectEndpoint(IMediator mediator)
    : BaseController
{
    [HttpGet]
    public async Task<ActionResult<Application.RedirectResult>> RedirectCode([FromBody] RedirectCommand code)
    {
        var result = await mediator.Send(code);
        return HandleResult(result, StatusCodes.Status308PermanentRedirect);
    }
}
