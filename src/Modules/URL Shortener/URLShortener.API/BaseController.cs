using Microsoft.AspNetCore.Mvc;
using Shared.Domain;
using URLShortener.Domain;

namespace URLShortener.API;

[ApiController]
[Route("api/shorturl")]
public abstract class BaseController : ControllerBase
{
    protected ActionResult HandleResult(Result result, int statusCode)
    {
        if(result.IsSuccess) return StatusCode(statusCode);

        return result.Error?.Code switch
        {
            ErrorCodes.NotFound => NotFound(result.Error.Message),
            ErrorCodes.BadRequest => BadRequest(result.Error.Message),
            _ => StatusCode(500, result.Error?.Message)
        };
    }

    protected ActionResult<T> HandleResult<T>(Result<T> result, int statusCode)
    {
        if (result.IsSuccess) return StatusCode(statusCode, result.Value);

        return result.Error?.Code switch
        {
            ErrorCodes.NotFound => NotFound(result.Error.Message),
            ErrorCodes.BadRequest => BadRequest(result.Error.Message),
            _ => StatusCode(500, result.Error?.Message)
        };
    }
}
