namespace AvroSerialize;

public class AvroDecimalAttribute : Attribute
{
    public int Precision { get; set; }

    public int Scale { get; set; }
}
