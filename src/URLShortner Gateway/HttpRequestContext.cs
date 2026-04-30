using Shared.Application;

namespace URLShortner_Gateway;

public class HttpRequestContext(IHttpContextAccessor httpContextAccessor)
    : IRequestContext
{
    public string? IpAddress
        => httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

    public string? UserAgent
        => httpContextAccessor.HttpContext?.Request.Headers.UserAgent.ToString();
}
