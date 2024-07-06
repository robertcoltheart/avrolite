using Avro;
using Avro.IO;
using Avro.Reflect;
using Avrocado.Benchmark.Models;

namespace Avrocado.Benchmark;

public class TestWriter
{
    public byte[] Write(AvroModel model)
    {
        var stream = new MemoryStream();

        var fields = new List<Field>
        {
            new(PrimitiveSchema.Create(Schema.Type.Int), "id", 0),
            new(UnionSchema.Create(new List<Schema>
            {
                PrimitiveSchema.Create(Schema.Type.Null),
                PrimitiveSchema.Create(Schema.Type.String)
            }), "address", 1),
            new(ArraySchema.Create(PrimitiveSchema.Create(Schema.Type.String)), "names", 2)
        };

        var schema = RecordSchema.Create("AvroModel", fields, "com.org");

        var writer = new ReflectWriter<AvroModel>(schema);
        writer.Write(model, new BinaryEncoder(stream));

        return stream.ToArray();
    }
}
