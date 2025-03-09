using System.Text.Json;
using Avrolite.Schemas;

namespace Avrolite.Serialization.Converters;

internal class RecordSchemaConverter : TrackedConverter<RecordSchema>
{
    public override RecordSchema? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options)
    {
        var type = reader.GetSchemaType();

        reader.ReadObject();

        var schema = type.Type == "error"
            ? new RecordSchema(SchemaType.Error)
            : new RecordSchema(SchemaType.Record);

        //tracked.Schemas[fullName] = schema;
        //tracked.SchemaTree.Push(schema);

        while (reader.IsInObject())
        {
            var property = reader.ReadMember();

            if (property == "name")
            {
                schema.SchemaName.Name = reader.GetString()!;
            }
            else if (property == "namespace")
            {
                schema.SchemaName.Namespace = reader.GetString()!;
            }
            else if (property == "doc")
            {
                schema.Documentation = reader.GetString()!;
            }
            else if (property == "aliases")
            {
                schema.Aliases = JsonSerializer.Deserialize<List<string>>(ref reader, options)!;
            }
            else if (property == "fields")
            {
                schema.Fields = reader.ReadTrackedList<FieldSchema>(tracked, options);
            }
            else
            {
                reader.Skip();
            }

            reader.Read();
        }

        return schema;
    }

    public override void Write(Utf8JsonWriter writer, RecordSchema value, TrackedResources tracked, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
