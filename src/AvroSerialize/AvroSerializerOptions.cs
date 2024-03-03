using System.Text.Json;
using AvroSerialize.Serialization;
using AvroSerialize.Serialization.Metadata;

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

    public AvroNamingPolicy? PropertyNamingPolicy { get; set; }

    public AvroNamingPolicy? TypeNamingPolicy { get; set; }

    public bool IgnoreReadOnlyProperties { get; set; }

    public bool IsReadOnly { get; }

    public bool PropertyNameCaseInsensitive { get; set; }

    public bool WriteIndented { get; set; }

    public IList<AvroConverter> Converters { get; }

    public IAvroSchemaInfoResolver? SchemaInfoResolver { get; set; }

    public IList<IAvroSchemaInfoResolver> SchmeaInfoResolverChain { get; }

    public AvroEncoder Encoder { get; set; }

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

    public AvroConverter GetConverter(Type type)
    {
        throw new NotImplementedException();
    }
}
