using System.Text.Json;
using Avrolite.Serialization.Converters;

namespace Avrolite.Serialization.Metadata;

internal static class JsonSerializerOptionsExtensions
{
    public static JsonSerializerOptions AddAvroConverter(this JsonSerializerOptions options)
    {
        options.Converters.Add(new SchemaConverterFactory());

        return options;
    }
}
