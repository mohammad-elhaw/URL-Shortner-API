using Shared.Domain;

namespace Shared.Application;

public interface IUrlResolver
{
    Task<Result<string>> Resolve(string shortCode);
}