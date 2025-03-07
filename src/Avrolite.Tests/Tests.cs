using Avrolite.Serialization.Metadata;
using Xunit;

namespace Avrolite.Tests;

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
