using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Messaging;

namespace Redirection.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRedirectionInfrastructure(
        this IServiceCollection services, IConfiguration config)
    {
        services.AddCapPublisher(config);
        return services;
    }
}
