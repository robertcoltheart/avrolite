namespace Avrolite.Serialization.Metadata.Schemas;

internal static class StringExtensions
{
    public static string? TrimQuotes(this string? value)
    {
        if (value?.StartsWith("\"") == true && value?.EndsWith("\"") == true)
        {
            return value[1..^1];
        }

        return value;
    }
}
