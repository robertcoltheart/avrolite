namespace AvroSerialize.Serialization.Metadata.Schemas;

internal class FixedSchema : NamedSchema
{
    public FixedSchema()
        : base(SchemaType.Fixed)
    {
    }

    public int Size { get; set; }
}
