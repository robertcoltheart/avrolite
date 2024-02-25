using System.Text.Json;

namespace AvroSerialize.Metadata.Schemas;

public class UnionSchema : TypeSchema
{
    public UnionSchema(SchemaType tag)
        : base(tag)
    {
    }

    public static UnionSchema Parse(JsonElement element)
    {
        return null;
    }
}
