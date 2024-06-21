using Avrocado;
using Avrocado.Benchmark;
using Avrocado.Serialization.Metadata;
using Avrocado.Serialization.Metadata.Schemas;
using BenchmarkDotNet.Running;

//BenchmarkRunner.Run<SerializeBenchmark>();

var data = File.ReadAllBytes(@"C:\Temp\avro.dat");

var recordSchema = new RecordSchema(SchemaType.Record);
recordSchema.SchemaName = new SchemaName("Agreement", "com.mgl.margining", "com.mgl.margining");
recordSchema.Fields.Add(new Field
{
    Name = "id",
    Schema = new PrimitiveSchema(SchemaType.Int)
});
recordSchema.Fields.Add(new Field
{
    Name = "address",
    Schema = new UnionSchema
    {
        Schemas = new List<Schema>
        {
            new PrimitiveSchema(SchemaType.String),
            new PrimitiveSchema(SchemaType.Null)
        }
    }
});
recordSchema.Fields.Add(new Field
{
    Name = "names",
    Schema = new ArraySchema
    {
        ItemSchema = new PrimitiveSchema(SchemaType.String),
        Parent = recordSchema
    }
});

SchemaTree.SetSchemaHierarchy(recordSchema);

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
