namespace AvroSerialize.Serialization.Metadata.Schemas;

public class PrimitiveSchema : UnnamedSchema
{
    public PrimitiveSchema(SchemaType tag)
        : base(tag)
    {
    }

    public string Type { get; set; }
}
