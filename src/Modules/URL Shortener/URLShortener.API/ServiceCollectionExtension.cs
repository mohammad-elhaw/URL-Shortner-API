using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using URLShortener.Application;

namespace URLShortener.API;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddUrlShortnerAPI(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddUrlShortnerApplication();
        return services;
    }
}
