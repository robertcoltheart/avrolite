namespace Avrolite.Schemas;

internal class ArraySchema() : UnnamedSchema(SchemaType.Array)
{
    public Schema ItemSchema { get; set; }
}
