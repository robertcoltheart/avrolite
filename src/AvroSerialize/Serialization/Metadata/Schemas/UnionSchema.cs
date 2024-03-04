namespace AvroSerialize.Serialization.Metadata.Schemas;

internal class UnionSchema : UnnamedSchema
{
    public UnionSchema()
        : base(SchemaType.Union)
    {
    }

    public Schema[] Schemas { get; set; }
}
