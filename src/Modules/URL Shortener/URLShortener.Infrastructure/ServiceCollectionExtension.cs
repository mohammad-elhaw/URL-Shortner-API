using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Application;
using URLShortener.Domain;
using URLShortener.Domain.Services;
using URLShortener.Infrastructure.Database;

namespace URLShortener.Infrastructure;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddURLShortenerInfrastructure(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddSingleton<IShortCodeGenerator>(sp =>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            var machineId = config.GetValue<long>("Snowflake:MachineId");

            return new SnowflakeShortCodeGenerator(machineId);
        });

        services.AddDbContext<ShortUrlDbContext>(opts =>
        {
            opts.UseSqlServer(config.GetConnectionString("Database"));
        });

        services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
        services.AddScoped<IUrlResolver, UrlResolver>();
        
        return services;
    }
}
