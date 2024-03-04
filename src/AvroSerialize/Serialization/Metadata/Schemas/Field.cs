namespace AvroSerialize.Serialization.Metadata.Schemas;

internal class Field
{
    public string Name { get; set; }

    public string Documentation { get; set; }

    public Schema Type { get; set; }

    public List<string> Aliases { get; set; } = new();
}
