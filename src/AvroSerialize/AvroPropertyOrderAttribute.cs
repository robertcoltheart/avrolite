namespace AvroSerialize;

[AttributeUsage(AttributeTargets.Property)]
public class AvroPropertyOrderAttribute : Attribute
{
    public AvroPropertyOrderAttribute(int order)
    {
        Order = order;
    }

    public int Order { get; }
}
