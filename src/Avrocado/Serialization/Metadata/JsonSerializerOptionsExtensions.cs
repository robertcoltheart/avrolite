using System.Text.Json;
using Avrocado.Serialization.Converters;

namespace Avrocado.Serialization.Metadata;

internal static class JsonSerializerOptionsExtensions
{
    public static JsonSerializerOptions AddAvroConverter(this JsonSerializerOptions options)
    {
        options.Converters.Add(new SchemaConverterFactory());

        return options;
    }
}
