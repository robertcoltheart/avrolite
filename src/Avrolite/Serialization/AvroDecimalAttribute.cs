namespace Avrolite.Serialization;

[AttributeUsage(AttributeTargets.Property)]
public class AvroDecimalAttribute : AvroAttribute
{
    public AvroDecimalAttribute(int precision, int scale)
    {
        Precision = precision;
        Scale = scale;
    }

    public int Precision { get; }

    public int Scale { get; }
}
