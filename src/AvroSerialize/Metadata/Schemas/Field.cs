namespace AvroSerialize.Metadata.Schemas;

public class Field
{
    public string Name { get; set; }

    public List<string> Aliases { get; } = new();

    public int Position { get; set; }
}
