using AvroSerialize.Serialization;
using AvroSerialize.Serialization.Metadata;
using AvroSerialize.Serialization.Metadata.Schemas;
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
    [InlineData("{\"type\":\"null\"}")]
    [InlineData("{\"type\":\"boolean\"}")]
    [InlineData("{\"type\":\"int\"}")]
    [InlineData("{\"type\":\"long\"}")]
    [InlineData("{\"type\":\"float\"}")]
    [InlineData("{\"type\":\"double\"}")]
    [InlineData("{\"type\":\"bytes\"}")]
    [InlineData("{\"type\":\"string\"}")]
    public void CanParseLongFormPrimitiveTypes(string json)
    {
        AvroSchemaInfo.Parse(json);
    }

    [Theory]
    [InlineData("{\"type\":\"record\",\"name\":\"Test\",\"fields\":[{\"name\":\"f\",\"type\":\"long\"}]}")]
    [InlineData("{\"type\":\"record\",\"name\":\"Test\",\"fields\":[{\"name\":\"f1\",\"type\":\"long\"},{\"name\":\"f2\",\"type\":\"int\"}]}")]
    [InlineData("{\"type\":\"error\",\"name\":\"Test\",\"fields\":[{\"name\":\"f1\",\"type\":\"long\"},{\"name\":\"f2\",\"type\":\"int\"}]}")]
    [InlineData("{\"type\":\"record\",\"name\":\"LongList\",\"fields\":[{\"name\":\"value\",\"type\":\"long\"},{\"name\":\"next\",\"type\":[\"LongList\",\"null\"]}]}")]
    [InlineData("{\"type\":\"record\",\"name\":\"LongList\",\"fields\":[{\"name\":\"value\",\"type\":\"long\"},{\"name\":\"next\",\"type\":[\"LongListA\",\"null\"]}]}", typeof(SchemaParseException))]
    [InlineData("{\"type\":\"record\",\"name\":\"LongList\"}", typeof(SchemaParseException))]
    [InlineData("{\"type\":\"record\",\"name\":\"LongList\",\"fields\":\"hi\"}", typeof(SchemaParseException))]
    [InlineData("[{\"type\":\"record\",\"name\":\"Test\",\"namespace\":\"ns1\",\"fields\":[{\"name\":\"f\",\"type\":\"long\"}]},{\"type\":\"record\",\"name\":\"Test\",\"namespace\":\"ns2\",\"fields\":[{\"name\":\"f\",\"type\":\"long\"}]}]")]
    public void CanParseRecordTypes(string json, Type expectedException = null)
    {
        ParseAndVerifyException(json, expectedException);
    }

    [Theory]
    [InlineData("{\"type\":\"record\",\"name\":\"Test\",\"doc\":\"Test Doc\",\"fields\":[{\"name\":\"f\",\"type\":\"long\"}]}")]
    public void CanParseRecordsWithDocumentation(string json)
    {
        AvroSchemaInfo.Parse(json);
    }

    [Theory]
    [InlineData("{\"type\":\"enum\",\"name\":\"Test\",\"symbols\":[\"A\",\"B\"]}")]
    [InlineData("{\"type\":\"enum\",\"name\":\"Status\",\"symbols\":\"Normal Caution Critical\"}", typeof(SchemaParseException))]
    [InlineData("{\"type\":\"enum\",\"name\":[0,1,1,2,3,5,8],\"symbols\":[\"Golden\",\"Mean\"]}", typeof(SchemaParseException))]
    [InlineData("{\"type\":\"enum\",\"symbols\":[\"I\",\"will\",\"fail\",\"no\",\"name\"]}", typeof(SchemaParseException))]
    [InlineData("{\"type\":\"enum\",\"name\":\"Test\",\"symbols\":[\"AA\",\"AA\"]}", typeof(SchemaParseException))]
    public void CanParseEnumType(string json, Type expectedException = null)
    {
        ParseAndVerifyException(json, expectedException);
    }

    [Theory]
    [InlineData("{\"type\":\"array\",\"items\":\"long\"}")]
    [InlineData("{\"type\":\"array\",\"items\":{\"type\":\"enum\",\"name\":\"Test\",\"symbols\":[\"A\",\"B\"]}}")]
    [InlineData("{\"type\":\"array\"}", typeof(SchemaParseException))]
    public void CanParseArray(string json, Type expectedException = null)
    {
        ParseAndVerifyException(json, expectedException);
    }

    [Theory]
    [InlineData("{\"type\":\"map\",\"values\":\"long\"}")]
    [InlineData("{\"type\":\"map\",\"values\":{\"type\":\"enum\",\"name\":\"Test\",\"symbols\":[\"A\", \"B\"]}}")]
    public void CanParseMap(string json)
    {
        AvroSchemaInfo.Parse(json);
    }

    [Theory]
    [InlineData("[\"string\",\"null\",\"long\"]")]
    [InlineData("[\"string\",\"long\",\"long\"]", typeof(SchemaParseException))]
    [InlineData("[{\"type\":\"array\",\"items\":\"long\"},{\"type\":\"array\",\"items\":\"string\"}]", typeof(SchemaParseException))]
    [InlineData("{\"type\":[\"string\",\"null\",\"long\"]}")]
    public void CanParseUnion(string json, Type expectedException = null)
    {
        ParseAndVerifyException(json, expectedException);
    }

    [Theory]
    [InlineData("{\"type\":\"fixed\",\"name\":\"Test\",\"size\":1}")]
    [InlineData("{\"type\":\"fixed\",\"name\":\"MyFixed\",\"namespace\":\"org.apache.hadoop.avro\",\"size\":1}")]
    [InlineData("{\"type\":\"fixed\",\"name\":\"Missing size\"}", typeof(SchemaParseException))]
    [InlineData("{\"type\":\"fixed\",\"size\":314}", typeof(SchemaParseException))]
    public void CanParseFixed(string json, Type expectedException = null)
    {
        ParseAndVerifyException(json, expectedException);
    }

    [Theory]
    [InlineData("{\"type\":\"null\",\"metafield\":\"abc\"}", "null")]
    [InlineData("{\"type\":\"boolean\",\"metafield\":\"abc\"}", "boolean")]
    [InlineData("{\"type\":\"int\",\"metafield\":\"abc\"}", "int")]
    [InlineData("{\"type\":\"long\",\"metafield\":\"abc\"}", "long")]
    [InlineData("{\"type\":\"float\",\"metafield\":\"abc\"}", "float")]
    [InlineData("{\"type\":\"double\",\"metafield\":\"abc\"}", "double")]
    [InlineData("{\"type\":\"bytes\",\"metafield\":\"abc\"}", "bytes")]
    [InlineData("{\"type\":\"string\",\"metafield\":\"abc\"}", "string")]
    public void CanParsePrimitiveWithMetadata(string json, string type)
    {
        var schema = AvroSchemaInfo.Parse(json);

        Assert.Equal(type, schema.ParsedSchema!.Tag.ToStringType());
    }

    private void ParseAndVerifyException(string json, Type expectedException = null)
    {
        if (expectedException == null)
        {
            AvroSchemaInfo.Parse(json);
        }
        else
        {
            Assert.Throws(expectedException, () => AvroSchemaInfo.Parse(json));
        }
    }
}
