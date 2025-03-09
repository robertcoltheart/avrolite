namespace Avrolite.Schemas;

internal class MapSchema() : UnnamedSchema(SchemaType.Map)
{
    public Schema ValueSchema { get; set; }
}
