using Analytics.Infrastructure;
using Redirection.Infrastructure;
using Shared.Infrastructure;
using URLShortener.API;
using URLShortener.Infrastructure;

namespace URLShortner_Gateway.Extensions;

public static class InitializeApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddControllers()
            .AddApplicationPart(typeof(URLShortener.API.AssemblyReference).Assembly)
            .AddApplicationPart(typeof(Redirection.API.AssemblyReference).Assembly)
            .AddApplicationPart(typeof(Analytics.API.AssembyReference).Assembly)
            .ConfigureApiBehaviorOptions(opts =>
            {
                opts.SuppressModelStateInvalidFilter = true;
            });

        services.AddUrlShortnerAPI(config);
        services.AddURLShortenerInfrastructure(config);
        services.AddRedirectionInfrastructure(config);
        services.AddAnalyticsInfrastructure(config);


        services.AddSharedInfrastructure(
            typeof(URLShortener.Application.ServiceCollectionExtension).Assembly,
            typeof(Redirection.Application.AssemblyReference).Assembly);

        return services;
    }
}
