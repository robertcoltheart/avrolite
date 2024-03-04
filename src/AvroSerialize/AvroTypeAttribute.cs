namespace AvroSerialize;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
public class AvroTypeAttribute : Attribute
{
    public AvroTypeAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

    public string Namespace { get; set; }
}
