namespace Avrolite.Schemas;

internal class MapSchema : UnnamedSchema
{
    public MapSchema()
        : base(SchemaType.Map)
    {
    }

    public Schema ValueSchema { get; set; }
}
