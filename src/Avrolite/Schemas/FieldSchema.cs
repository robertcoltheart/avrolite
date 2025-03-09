namespace Avrolite.Schemas;

internal class FieldSchema() : NamedSchema(SchemaType.Field)
{
    public Schema Schema { get; set; }

    public SortOrder? Order { get; set; }

    public object? DefaultValue { get; set; }
}
