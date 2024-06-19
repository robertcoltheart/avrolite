namespace Avrocado.Serialization.Metadata.Schemas;

internal class ArraySchema : UnnamedSchema
{
    public ArraySchema()
        : base(SchemaType.Array)
    {
    }

    public Schema? ItemSchema { get; set; }
}
