namespace AvroSerialize.Serialization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum)]
public class AvroTypeAttribute : AvroAttribute
{
    public string Name { get; set; }

    public string Namespace { get; set; }
}
