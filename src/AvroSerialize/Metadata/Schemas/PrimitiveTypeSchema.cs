namespace AvroSerialize.Metadata.Schemas;

public class PrimitiveTypeSchema : TypeSchema
{
    public PrimitiveTypeSchema(SchemaType tag)
        : base(tag)
    {
    }

    public static PrimitiveTypeSchema? Parse(string? type)
    {
        type = type.TrimQuotes();

        return type switch
        {
            "null" => new PrimitiveTypeSchema(SchemaType.Null),
            "boolean" => new PrimitiveTypeSchema(SchemaType.Boolean),
            "int" => new PrimitiveTypeSchema(SchemaType.Int),
            "long" => new PrimitiveTypeSchema(SchemaType.Long),
            "float" => new PrimitiveTypeSchema(SchemaType.Float),
            "double" => new PrimitiveTypeSchema(SchemaType.Double),
            "bytes" => new PrimitiveTypeSchema(SchemaType.Bytes),
            "string" => new PrimitiveTypeSchema(SchemaType.String),
            _ => null
        };
    }
}
