namespace Avrolite.Schemas;

internal class UnionSchema : UnnamedSchema
{
    public UnionSchema()
        : base(SchemaType.Union)
    {
    }

    public List<Schema> Schemas { get; set; } = new();
}
