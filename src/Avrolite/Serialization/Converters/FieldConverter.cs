using System.Text.Json;
using Avrolite.Schemas;

namespace Avrolite.Serialization.Converters;

internal class FieldConverter : TrackedConverter<FieldSchema>
{
    public override FieldSchema? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options)
    {
        reader.ReadObject();

        var field = new FieldSchema();

        while (reader.IsInObject())
        {
            var property = reader.ReadMember();

            if (property == "name")
            {
                //field.Name = reader.GetString()!;
            }
            else if (property == "doc")
            {
                field.Documentation = reader.GetString()!;
            }
            else if (property == "type")
            {
                field.Schema = reader.ReadTracked<Schema>(tracked, options)!;
            }
            else if (property == "aliases")
            {
                field.Aliases = JsonSerializer.Deserialize<List<string>>(ref reader, options)!;
            }
            else
            {
                reader.Skip();
            }

            reader.Read();
        }

        return field;
    }

    public override void Write(Utf8JsonWriter writer, FieldSchema value, TrackedResources tracked, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
