namespace Avrocado.Serialization.Metadata.Schemas;

internal class FieldSchema : NamedSchema
{
    public FieldSchema()
        : base(SchemaType.Field)
    {
    }

    public Schema Schema { get; set; }

    public SortOrder? Order { get; set; }

    public object? DefaultValue { get; set; }
}
