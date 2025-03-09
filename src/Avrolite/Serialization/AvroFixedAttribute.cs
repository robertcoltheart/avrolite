namespace Avrolite.Serialization;

[AttributeUsage(AttributeTargets.Property)]
public class AvroFixedAttribute(int size) : AvroAttribute
{
    public int Size { get; } = size;
}
