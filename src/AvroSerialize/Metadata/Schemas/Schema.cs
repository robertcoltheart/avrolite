using System.Text.Json;

namespace AvroSerialize.Metadata.Schemas;

public abstract class Schema
{
    protected Schema(SchemaType tag)
    {
        Tag = tag;
    }

    public SchemaType Tag { get; }

    public abstract string Name { get; }

    public static Schema Parse(string json, SchemaNames names)
    {
        var document = JsonDocument.Parse(json);
        var element = document.RootElement;

        if (element.ValueKind == JsonValueKind.String)
        {
            var primitive = PrimitiveTypeSchema.Parse(element.GetString());

            if (primitive != null)
            {
                return primitive;
            }

            if (names.Contains(element.GetString()))
            {
                return names.Names[element.GetString()];
            }

            throw new InvalidOperationException($"Undefined name: {element.GetString()}");
        }

        if (element.ValueKind == JsonValueKind.Array)
        {
            return UnionSchema.Parse(element);
        }


        throw new InvalidOperationException($"Invalid JSON for schema: {element}");
    }
}
