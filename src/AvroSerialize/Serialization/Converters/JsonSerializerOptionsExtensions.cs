using System.Text.Json;

namespace AvroSerialize.Serialization.Converters;

internal static class JsonSerializerOptionsExtensions
{
    public static TrackedConverter<T> GetTrackedConverter<T>(this JsonSerializerOptions options)
    {
        var converter = options.GetConverter(typeof(T));

        if (converter is not TrackedConverter<T> trackedConverter)
        {
            throw new InvalidOperationException();
        }

        return trackedConverter;
    }
}
