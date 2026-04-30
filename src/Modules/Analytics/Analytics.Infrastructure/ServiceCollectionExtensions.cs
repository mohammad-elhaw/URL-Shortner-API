using Analytics.Application;
using Analytics.Domain;
using Analytics.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Messaging;

namespace Analytics.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAnalyticsInfrastructure(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<AnalyticsDbContext>(opts =>
        {
            opts.UseSqlServer(config.GetConnectionString("Database"));
        });

        services.AddScoped<UrlResolvedIntegrationEventHandler>();
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddCapConsumer(config);
        return services;
    }
}
