using System.Text;

namespace URLShortener.Infrastructure;

public static class Base62
{
    private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public static string Encode(long value)
    {
        if (value == 0) return "0";

        var result = new StringBuilder();

        while (value > 0)
        {
            result.Insert(0, Alphabet[(int)(value % 62)]);
            value /= 62;
        }

        return result.ToString();
    }
}
