using AvroSchemaGenerator;
using AvroSerialize.Serialization.Metadata;
using AvroSerialize.Serialization.Metadata.Schemas;
using Xunit;

namespace AvroSerialize.Tests;

public class Tests
{
    [Fact]
    public void Test()
    {
        var json = File.ReadAllText("ClassModel.avsc");

        var schema = AvroSchemaInfo.Parse(json);
        var result = schema.Schema;
    }
}
