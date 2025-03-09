namespace Avrolite.Serialization;

[AttributeUsage(AttributeTargets.Property)]
public class AvroPropertyOrderAttribute(int order) : AvroAttribute
{
    public int Order { get; } = order;
}
