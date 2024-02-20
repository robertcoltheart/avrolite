namespace AvroSerialize.Metadata;

public sealed class AvroSchemaInfo<T> : AvroSchemaInfo
{
    internal AvroSchemaInfo()
    {
    }
}

public abstract class AvroSchemaInfo
{
    internal AvroSchemaInfo()
    {
    }

    public static AvroSchemaInfo CreateSchemaInfo<T>(AvroSerializerOptions? options = null)
    {
        throw new NotImplementedException();
    }

    public static AvroSchemaInfo CreateSchemaInfo(Type type, AvroSerializerOptions? options = null)
    {
        throw new NotImplementedException();
    }
}
