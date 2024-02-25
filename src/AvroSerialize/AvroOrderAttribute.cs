namespace AvroSerialize;

[AttributeUsage(AttributeTargets.Property)]
public class AvroOrderAttribute : Attribute
{
    public AvroOrderAttribute(int order)
    {
        Order = order;
    }

    public int Order { get; }
}
