namespace Shared.Application;

public interface IRequestContext
{
    string? IpAddress { get; }
    string? UserAgent { get; }
}
