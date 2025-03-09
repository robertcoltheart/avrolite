using Avrolite.Schemas;

namespace Avrolite;

public struct AvroReaderOptions
{
    public int MaxDepth { get; set; }

    public Schema Schema { get; set; }
}
