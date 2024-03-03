using System.Text.Json;
using AvroSerialize.Serialization.Metadata.Schemas;

namespace AvroSerialize.Serialization.Converters;

public class EnumSchemaConverter : TrackedConverter<EnumSchema>
{
    public override EnumSchema? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options)
    {
        reader.Read();

        var schema = new EnumSchema(SchemaType.Int);

        return schema;
    }

    public override void Write(Utf8JsonWriter writer, EnumSchema value, TrackedResources tracked, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
