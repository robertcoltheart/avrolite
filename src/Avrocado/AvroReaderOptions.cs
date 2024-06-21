using Avrocado.Serialization.Metadata.Schemas;

namespace Avrocado;

public struct AvroReaderOptions
{
    public int MaxDepth { get; set; }

    public Schema Schema { get; set; }
}
