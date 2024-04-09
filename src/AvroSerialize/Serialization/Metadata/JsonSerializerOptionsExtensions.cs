using System.Text.Json;
using AvroSerialize.Serialization.Converters;

namespace AvroSerialize.Serialization.Metadata;

internal static class JsonSerializerOptionsExtensions
{
    public static JsonSerializerOptions AddAvroConverter(this JsonSerializerOptions options)
    {
        options.Converters.Add(new SchemaConverterFactory());

        return options;
    }
}
