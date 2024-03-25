using AvroSerialize.Serialization.Metadata.Types;

namespace AvroSerialize.Serialization.Metadata.Schemas;

internal class LogicalSchema : UnnamedSchema
{
    public LogicalSchema()
        : base(SchemaType.Logical)
    {
    }

    public Schema BaseSchema { get; set; }

    public string LogicalTypeName { get; set; }

    public LogicalType LogicalType { get; set; }

    public override string Name => BaseSchema.Name;

    public override string FullName => BaseSchema.FullName;
}
