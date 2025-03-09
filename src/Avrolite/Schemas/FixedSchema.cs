namespace Avrolite.Schemas;

internal class FixedSchema() : NamedSchema(SchemaType.Fixed)
{
    public int Size { get; set; }
}
