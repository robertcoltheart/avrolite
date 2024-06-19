using AvroSchemaGenerator;
using Avrocado.Serialization.Metadata;
using Avrocado.Serialization.Metadata.Schemas;
using Xunit;

namespace Avrocado.Tests;

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
