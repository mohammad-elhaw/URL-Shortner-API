using Microsoft.Extensions.DependencyInjection;

namespace URLShortener.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddUrlShortnerApplication(this IServiceCollection services)
    {
        return services;
    }
}
