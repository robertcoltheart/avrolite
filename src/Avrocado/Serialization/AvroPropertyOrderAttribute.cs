namespace Avrocado.Serialization;

[AttributeUsage(AttributeTargets.Property)]
public class AvroPropertyOrderAttribute : AvroAttribute
{
    public AvroPropertyOrderAttribute(int order)
    {
        Order = order;
    }

    public int Order { get; }
}
