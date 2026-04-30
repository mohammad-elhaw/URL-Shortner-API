using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Shared.Messaging;

public static class CapExtensions
{
    public static IServiceCollection AddCapPublisher<TDbContext>(this IServiceCollection services,
        IConfiguration config)
        where TDbContext : DbContext
    {

        services.AddCap(opts =>
        {
            opts.UseSqlServer(config.GetConnectionString("Database")!);
            opts.UseEntityFramework<TDbContext>();
            ConfigureRabbitMQ(opts, config);
        });
        services.AddScoped<IMessageBus, CapMessageBus>();

        return services;
    }

    public static IServiceCollection AddCapPublisher(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddCap(options =>
        {
            options.UseSqlServer(config.GetConnectionString("Database")!);
            ConfigureRabbitMQ(options, config);
        });
        services.AddScoped<IMessageBus, CapMessageBus>();
        return services;
    }

    public static IServiceCollection AddCapConsumer(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddCap(options =>
        {
            ConfigureRabbitMQ(options, config);
        });
        return services;
    }

    public static void ConfigureRabbitMQ(CapOptions options, IConfiguration config)
    {
        options.UseRabbitMQ(cfg =>
        {
            cfg.HostName = config["MessageBroker:Host"]!;
            cfg.Port = int.Parse(config["MessageBroker:Port"] ?? "5672");
            cfg.UserName = config["MessageBroker:Username"]!;
            cfg.Password = config["MessageBroker:Password"]!;
            cfg.VirtualHost = config["MessageBroker:VirtualHost"] ?? "/";
        });
    }
}
