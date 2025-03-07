namespace Avrolite.Serialization.Metadata.Schemas;

internal class PrimitiveSchema : UnnamedSchema
{
    public PrimitiveSchema(SchemaType tag)
        : base(tag)
    {
    }

    public string Type { get; set; }
}
