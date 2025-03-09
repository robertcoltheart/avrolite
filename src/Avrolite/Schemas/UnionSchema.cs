namespace Avrolite.Schemas;

internal class UnionSchema() : UnnamedSchema(SchemaType.Union)
{
    public List<Schema> Schemas { get; set; } = new();
}
