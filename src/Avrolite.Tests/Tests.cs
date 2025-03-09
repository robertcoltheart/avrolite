using Avrolite.Serialization.Metadata;

namespace Avrolite.Tests;

public class Tests
{
    [Test]
    public void Test()
    {
        var json = File.ReadAllText("ClassModel.avsc");

        var schema = AvroSchemaInfo.Parse(json);
        var result = schema.Schema;
    }
}
