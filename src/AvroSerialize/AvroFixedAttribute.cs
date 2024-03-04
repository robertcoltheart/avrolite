namespace AvroSerialize;

[AttributeUsage(AttributeTargets.Property)]
public class AvroFixedAttribute : Attribute
{
    public AvroFixedAttribute(int size)
    {
        Size = size;
    }

    public int Size { get; }
}
