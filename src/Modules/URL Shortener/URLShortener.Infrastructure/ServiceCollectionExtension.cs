using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using URLShortener.Domain.Services;

namespace URLShortener.Infrastructure;

public static class ServiceCollectionExtension
{
        public static IServiceCollection AddURLShortenerInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IShortCodeGenerator>(sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var machineId = config.GetValue<long>("Snowflake:MachineId");

                return new SnowflakeShortCodeGenerator(machineId);
            });
            return services;
    }
}
