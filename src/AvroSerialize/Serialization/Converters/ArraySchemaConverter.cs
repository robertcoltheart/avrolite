using System.Text.Json;
using AvroSerialize.Serialization.Metadata.Schemas;

namespace AvroSerialize.Serialization.Converters;

internal class ArraySchemaConverter : TrackedConverter<ArraySchema>
{
    public override ArraySchema? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options)
    {
        reader.ReadObject();

        var schema = new ArraySchema();

        while (reader.IsInObject())
        {
            var property = reader.ReadMember();

            if (property == "items")
            {
                schema.ItemSchema = reader.ReadTracked<Schema>(tracked, options)!;
            }
            else
            {
                reader.Skip();
            }

            reader.Read();
        }

        return schema;
    }

    public override void Write(Utf8JsonWriter writer, ArraySchema value, TrackedResources tracked, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
