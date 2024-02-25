namespace AvroSerialize.Metadata.Schemas;

public class PrimitiveSchema : UnnamedSchema
{
    public PrimitiveSchema(SchemaType tag)
        : base(tag)
    {
    }

    public static PrimitiveSchema? Parse(string? type)
    {
        type = type.TrimQuotes();

        return type switch
        {
            "null" => new PrimitiveSchema(SchemaType.Null),
            "boolean" => new PrimitiveSchema(SchemaType.Boolean),
            "int" => new PrimitiveSchema(SchemaType.Int),
            "long" => new PrimitiveSchema(SchemaType.Long),
            "float" => new PrimitiveSchema(SchemaType.Float),
            "double" => new PrimitiveSchema(SchemaType.Double),
            "bytes" => new PrimitiveSchema(SchemaType.Bytes),
            "string" => new PrimitiveSchema(SchemaType.String),
            _ => null
        };
    }
}
