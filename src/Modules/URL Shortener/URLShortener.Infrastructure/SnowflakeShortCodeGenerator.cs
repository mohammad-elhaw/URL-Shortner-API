using URLShortener.Domain.Services;

namespace URLShortener.Infrastructure;

public class SnowflakeShortCodeGenerator(long machineId) : IShortCodeGenerator
{
    private readonly SnowflakeGenerator _snowflake = new (machineId);

    public string Generate()
    {
        long id = _snowflake.NextId();
        return Base62.Encode(id);
    }
}