using AvroSerialize.Metadata;

namespace AvroSerialize;

public class AvroSerializerOptions
{
    public AvroSerializerOptions()
    {
    }

    public AvroSerializerOptions(AvroSerializerOptions options)
    {
    }

    public static AvroSerializerOptions Default { get; }

    public AvroNamingPolicy? EnumNamingPolicy { get; set; }

    public AvroNamingPolicy? PropertyNamingPolicy { get; set; }

    public bool IgnoreReadOnlyFields { get; set; }

    public bool IgnoreReadOnlyProperties { get; set; }

    public bool IsReadOnly { get; }

    public bool PropertyNameCaseInsensitive { get; set; }

    public void MakeReadOnly()
    {
        throw new NotImplementedException();
    }

    public AvroSchemaInfo GetSchemaInfo(Type type)
    {
        throw new NotImplementedException();
    }

    public bool TryGetSchemaInfo(Type type, out AvroSchemaInfo? schemaInfo)
    {
        throw new NotImplementedException();
    }
}
