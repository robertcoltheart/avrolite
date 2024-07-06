using Avrocado;
using Avrocado.Benchmark;
using Avrocado.Benchmark.Models;
using Avrocado.Serialization.Metadata;
using Avrocado.Serialization.Metadata.Schemas;

var data = CreateAvroStream();

var options = new AvroReaderOptions { Schema = CreateSchema() };
var reader = new AvroReader(data, options);

while (reader.Read())
{
    if (reader.TokenType == AvroTokenType.Number)
    {
        var i = reader.GetInt64();
    }

    Console.WriteLine(reader.TokenType);
}

static byte[] CreateAvroStream()
{
    var model = new AvroModel
    {
        Id = 2,
        Address = "abc",
        Names = new List<string>
        {
            "dick",
            "jane"
        }
    };

    var writer = new TestWriter();

    return writer.Write(model);
}

static Schema CreateSchema()
{
    var recordSchema = new RecordSchema(SchemaType.Record);
    recordSchema.SchemaName = new SchemaName("AvroModel", "com.org", "com.org");
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

    return recordSchema;
}
