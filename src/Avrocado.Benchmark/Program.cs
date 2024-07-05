using Avro.Reflect;
using Avrocado;
using Avrocado.Benchmark.Models;
using Avrocado.Serialization.Metadata;
using Avrocado.Serialization.Metadata.Schemas;

var data = File.ReadAllBytes(args[0]);

var recordSchema = new RecordSchema(SchemaType.Record);
recordSchema.SchemaName = new SchemaName(args[1], args[2], args[2]);
recordSchema.Fields.Add(new FieldSchema
{
    SchemaName = new SchemaName("id", recordSchema.Namespace, recordSchema.Namespace),
    Schema = new PrimitiveSchema(SchemaType.Int)
});
recordSchema.Fields.Add(new FieldSchema
{
    SchemaName = new SchemaName("address", recordSchema.Namespace, recordSchema.Namespace),
    Schema = new UnionSchema
    {
        Schemas = new List<Schema>
        {
            new PrimitiveSchema(SchemaType.String),
            new PrimitiveSchema(SchemaType.Null)
        }
    }
});
recordSchema.Fields.Add(new FieldSchema
{
    SchemaName = new SchemaName("names", recordSchema.Namespace, recordSchema.Namespace),
    Schema = new ArraySchema
    {
        ItemSchema = new PrimitiveSchema(SchemaType.String)
    }
});

var visitor = new SchemaVisitor();
visitor.Visit(recordSchema);

var options = new AvroReaderOptions { Schema = recordSchema };
var reader = new AvroReader(data, options);

while (reader.Read())
{
    if (reader.TokenType == AvroTokenType.Number)
    {
        var i = reader.GetInt64();
    }

    Console.WriteLine(reader.TokenType);
}
