using System.Text.Json;

namespace AvroSerialize.Serialization.Converters;

internal static class Utf8JsonWriterExtensions
{
    public static void WriteStringOrDefault(this Utf8JsonWriter writer, string propertyName, string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            writer.WriteString(propertyName, value);
        }
    }
}
