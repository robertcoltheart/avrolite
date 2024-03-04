using System.Text.Json;
using AvroSerialize.Serialization.Metadata.Schemas;

namespace AvroSerialize.Serialization.Converters;

internal class EnumSchemaConverter : TrackedConverter<EnumSchema>
{
    public override EnumSchema? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options)
    {
        reader.ReadObject();

        var schema = new EnumSchema();

        while (reader.IsInObject())
        {
            var property = reader.ReadMember();

            if (property == "name")
            {
                //schema.Name = reader.GetString();
            }
            else if (property == "namespace")
            {
                //schema.SchemaName.Namespace = reader.GetString();
            }
            else if (property == "aliases")
            {
                schema.Aliases = JsonSerializer.Deserialize<List<string>>(ref reader, options)!;
            }
            else if (property == "doc")
            {
                schema.Documentation = reader.GetString()!;
            }
            else if (property == "symbols")
            {
                schema.Symbols = JsonSerializer.Deserialize<List<string>>(ref reader, options)!;
            }
            else if (property == "default")
            {
                schema.Default = reader.GetString()!;
            }
            else
            {
                reader.Skip();
            }

            reader.Read();
        }

        return schema;
    }

    public override void Write(Utf8JsonWriter writer, EnumSchema value, TrackedResources tracked, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
