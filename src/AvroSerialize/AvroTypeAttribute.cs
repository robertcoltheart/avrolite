namespace AvroSerialize;

public class AvroTypeAttribute : Attribute
{
    public string Name { get; set; }

    public string Namespace { get; set; }
}
