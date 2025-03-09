using Avrolite.Serialization.Metadata.Types;

namespace Avrolite.Schemas;

internal class LogicalSchema() : UnnamedSchema(SchemaType.Logical)
{
    public Schema BaseSchema { get; set; }

    public string LogicalTypeName { get; set; }

    public LogicalType LogicalType { get; set; }

    public override string Name => BaseSchema.Name;

    public override string FullName => BaseSchema.FullName;
}
