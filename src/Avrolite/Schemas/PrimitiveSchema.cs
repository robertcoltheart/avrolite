namespace Avrolite.Schemas;

internal class PrimitiveSchema(SchemaType tag) : UnnamedSchema(tag)
{
    public string Type { get; set; }
}
