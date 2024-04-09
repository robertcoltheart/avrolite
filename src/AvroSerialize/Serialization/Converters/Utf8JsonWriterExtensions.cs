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

    public static void WriteTracked<T>(this Utf8JsonWriter writer, T value, TrackedResources tracked, JsonSerializerOptions options)
    {
        var converter = options.GetTrackedConverter<T>();

        converter.Write(writer, value, tracked, options);
    }
}
