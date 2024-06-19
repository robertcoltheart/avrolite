using System.Text.Json;
using Avrocado.Serialization.Metadata.Schemas;

namespace Avrocado.Serialization.Converters;

internal abstract class NamedSchemaConverter<T> : TrackedConverter<T>
    where T : NamedSchema, new()
{
    public abstract void ReadField(ref Utf8JsonReader reader, T schema, string property, TrackedResources tracked, JsonSerializerOptions options);

    public virtual void Validate(T schema)
    {
    }

    public sealed override T? Read(ref Utf8JsonReader reader, Type typeToConvert, TrackedResources tracked, JsonSerializerOptions options)
    {
        reader.ReadObject();

        var schema = new T();

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
            else if (property == "aliases")
            {
                schema.Aliases = JsonSerializer.Deserialize<List<string>>(ref reader, options);
            }
            else if (property == "doc")
            {
                schema.Documentation = reader.GetString();
            }
            else
            {
                ReadField(ref reader, schema, property, tracked, options);
            }

            reader.Read();
        }

        Validate(schema);

        return schema;
    }

    public abstract void WriteFields(Utf8JsonWriter writer, T value, TrackedResources tracked, JsonSerializerOptions options);

    public sealed override void Write(Utf8JsonWriter writer, T value, TrackedResources tracked, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        // TODO: If schema is already in list, write name only

        if (!string.IsNullOrEmpty(value.SchemaName.Name))
        {
            writer.WriteStringOrDefault("name", value.SchemaName.Name);
            writer.WriteStringOrDefault("doc", value.Documentation);
            writer.WriteStringOrDefault("namespace", value.SchemaName.Namespace);

            if (!string.IsNullOrEmpty(value.SchemaName.Namespace))
            {
                writer.WriteString("namespace", value.SchemaName.Namespace);
            }
            else if (!string.IsNullOrEmpty(value.SchemaName.EnclosingNamespace))
            {
                writer.WriteString("namespace", value.SchemaName.EnclosingNamespace);
            }
        }

        if (value.Aliases != null)
        {
            writer.WriteStartArray("aliases");

            foreach (var alias in value.Aliases)
            {
                writer.WriteStringValue(alias);
            }

            writer.WriteEndArray();
        }

        WriteFields(writer, value, tracked, options);

        writer.WriteEndObject();
    }
}
