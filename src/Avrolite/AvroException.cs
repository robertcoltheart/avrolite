namespace Avrolite;

public class AvroException : Exception
{
    public AvroException()
    {
    }

    public AvroException(string? message)
        : base(message)
    {
    }
}
