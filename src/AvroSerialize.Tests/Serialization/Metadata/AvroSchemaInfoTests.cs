using AvroSerialize.Serialization;
using AvroSerialize.Serialization.Metadata;
using Xunit;

namespace AvroSerialize.Tests.Serialization.Metadata;

public class AvroSchemaInfoTests
{
    [Theory]
    [InlineData("null")]
    [InlineData("boolean")]
    [InlineData("int")]
    [InlineData("long")]
    [InlineData("float")]
    [InlineData("double")]
    [InlineData("bytes")]
    [InlineData("string")]
    public void CanParseShortHandPrimitiveTypes(string json)
    {
        AvroSchemaInfo.Parse(json);
    }

    [Theory]
    [InlineData("\"null\"")]
    [InlineData("\"boolean\"")]
    [InlineData("\"int\"")]
    [InlineData("\"long\"")]
    [InlineData("\"float\"")]
    [InlineData("\"double\"")]
    [InlineData("\"bytes\"")]
    [InlineData("\"string\"")]
    public void CanParseShortHandPrimitiveTypesWithQuotes(string json)
    {
        AvroSchemaInfo.Parse(json);
    }

    [Theory]
    [InlineData("{ \"type\": \"null\" }")]
    [InlineData("{ \"type\": \"boolean\" }")]
    [InlineData("{ \"type\": \"int\" }")]
    [InlineData("{ \"type\": \"long\" }")]
    [InlineData("{ \"type\": \"float\" }")]
    [InlineData("{ \"type\": \"double\" }")]
    [InlineData("{ \"type\": \"bytes\" }")]
    [InlineData("{ \"type\": \"string\" }")]
    public void CanParseLongFormPrimitiveTypes(string json)
    {
        AvroSchemaInfo.Parse(json);
    }

    [Theory]
    [InlineData("{\"type\": \"record\",\"name\": \"Test\",\"fields\": [{\"name\": \"f\",\"type\": \"long\"}]}")]
    [InlineData("{\"type\": \"record\",\"name\": \"Test\",\"fields\": [{\"name\": \"f1\",\"type\": \"long\"},{\"name\": \"f2\", \"type\": \"int\"}]}")]
    [InlineData("{\"type\": \"error\",\"name\": \"Test\",\"fields\": [{\"name\": \"f1\",\"type\": \"long\"},{\"name\": \"f2\", \"type\": \"int\"}]}")]
    [InlineData("{\"type\":\"record\",\"name\":\"LongList\",\"fields\":[{\"name\":\"value\",\"type\":\"long\"},{\"name\":\"next\",\"type\":[\"LongList\",\"null\"]}]}")]
    [InlineData("{\"type\":\"record\",\"name\":\"LongList\",\"fields\":[{\"name\":\"value\",\"type\":\"long\"},{\"name\":\"next\",\"type\":[\"LongListA\",\"null\"]}]}", typeof(SchemaParseException))]
    [InlineData("{\"type\":\"record\",\"name\":\"LongList\"}", typeof(SchemaParseException))]
    [InlineData("{\"type\":\"record\",\"name\":\"LongList\", \"fields\": \"hi\"}", typeof(SchemaParseException))]
    [InlineData("[{\"type\": \"record\",\"name\": \"Test\",\"namespace\":\"ns1\",\"fields\": [{\"name\": \"f\",\"type\": \"long\"}]},{\"type\": \"record\",\"name\": \"Test\",\"namespace\":\"ns2\",\"fields\": [{\"name\": \"f\",\"type\": \"long\"}]}]")]
    public void CanParseRecords(string json, Type expectedException = null)
    {
    }
}
