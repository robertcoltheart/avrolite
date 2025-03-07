using System.Text.Json;
using System.Text.Json.Serialization;
using Avrolite.Serialization.Metadata.Schemas;

namespace Avrolite.Serialization.Converters;

internal class SchemaConverterFactory : JsonConverterFactory
{
    private readonly Dictionary<Type, JsonConverter> converters = new()
    {
        { typeof(RecordSchema), new RecordSchemaConverter() },
        { typeof(FieldSchema), new FieldConverter() },
        { typeof(LogicalSchema), new LogicalSchemaConverter() },
        { typeof(EnumSchema), new EnumSchemaConverter() },
        { typeof(ArraySchema), new ArraySchemaConverter() },
        { typeof(UnionSchema), new UnionSchemaConverter() }
    };

    public override bool CanConvert(Type typeToConvert)
    {
        return converters.ContainsKey(typeToConvert);
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return converters[typeToConvert];
    }
}
