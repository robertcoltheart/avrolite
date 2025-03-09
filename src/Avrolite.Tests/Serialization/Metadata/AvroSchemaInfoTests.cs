using Avrolite.Schemas;
using Avrolite.Serialization;
using Avrolite.Serialization.Metadata;

namespace Avrolite.Tests.Serialization.Metadata;

public class AvroSchemaInfoTests
{
    [Test]
    [Arguments("null")]
    [Arguments("boolean")]
    [Arguments("int")]
    [Arguments("long")]
    [Arguments("float")]
    [Arguments("double")]
    [Arguments("bytes")]
    [Arguments("string")]
    public void CanParseShortHandPrimitiveTypes(string json)
    {
        AvroSchemaInfo.Parse(json);
    }

    [Test]
    [Arguments("\"null\"")]
    [Arguments("\"boolean\"")]
    [Arguments("\"int\"")]
    [Arguments("\"long\"")]
    [Arguments("\"float\"")]
    [Arguments("\"double\"")]
    [Arguments("\"bytes\"")]
    [Arguments("\"string\"")]
    public void CanParseShortHandPrimitiveTypesWithQuotes(string json)
    {
        AvroSchemaInfo.Parse(json);
    }

    [Test]
    [Arguments("{\"type\":\"null\"}")]
    [Arguments("{\"type\":\"boolean\"}")]
    [Arguments("{\"type\":\"int\"}")]
    [Arguments("{\"type\":\"long\"}")]
    [Arguments("{\"type\":\"float\"}")]
    [Arguments("{\"type\":\"double\"}")]
    [Arguments("{\"type\":\"bytes\"}")]
    [Arguments("{\"type\":\"string\"}")]
    public void CanParseLongFormPrimitiveTypes(string json)
    {
        AvroSchemaInfo.Parse(json);
    }

    [Test]
    [Arguments("{\"type\":\"record\",\"name\":\"Test\",\"fields\":[{\"name\":\"f\",\"type\":\"long\"}]}")]
    [Arguments("{\"type\":\"record\",\"name\":\"Test\",\"fields\":[{\"name\":\"f1\",\"type\":\"long\"},{\"name\":\"f2\",\"type\":\"int\"}]}")]
    [Arguments("{\"type\":\"error\",\"name\":\"Test\",\"fields\":[{\"name\":\"f1\",\"type\":\"long\"},{\"name\":\"f2\",\"type\":\"int\"}]}")]
    [Arguments("{\"type\":\"record\",\"name\":\"LongList\",\"fields\":[{\"name\":\"value\",\"type\":\"long\"},{\"name\":\"next\",\"type\":[\"LongList\",\"null\"]}]}")]
    [Arguments("{\"type\":\"record\",\"name\":\"LongList\",\"fields\":[{\"name\":\"value\",\"type\":\"long\"},{\"name\":\"next\",\"type\":[\"LongListA\",\"null\"]}]}", typeof(SchemaParseException))]
    [Arguments("{\"type\":\"record\",\"name\":\"LongList\"}", typeof(SchemaParseException))]
    [Arguments("{\"type\":\"record\",\"name\":\"LongList\",\"fields\":\"hi\"}", typeof(SchemaParseException))]
    [Arguments("[{\"type\":\"record\",\"name\":\"Test\",\"namespace\":\"ns1\",\"fields\":[{\"name\":\"f\",\"type\":\"long\"}]},{\"type\":\"record\",\"name\":\"Test\",\"namespace\":\"ns2\",\"fields\":[{\"name\":\"f\",\"type\":\"long\"}]}]")]
    public void CanParseRecordTypes(string json, Type expectedException = null)
    {
        ParseAndVerifyException(json, expectedException);
    }

    [Test]
    [Arguments("{\"type\":\"record\",\"name\":\"Test\",\"doc\":\"Test Doc\",\"fields\":[{\"name\":\"f\",\"type\":\"long\"}]}")]
    public void CanParseRecordsWithDocumentation(string json)
    {
        AvroSchemaInfo.Parse(json);
    }

    [Test]
    [Arguments("{\"type\":\"enum\",\"name\":\"Test\",\"symbols\":[\"A\",\"B\"]}")]
    [Arguments("{\"type\":\"enum\",\"name\":\"Status\",\"symbols\":\"Normal Caution Critical\"}", typeof(SchemaParseException))]
    [Arguments("{\"type\":\"enum\",\"name\":[0,1,1,2,3,5,8],\"symbols\":[\"Golden\",\"Mean\"]}", typeof(SchemaParseException))]
    [Arguments("{\"type\":\"enum\",\"symbols\":[\"I\",\"will\",\"fail\",\"no\",\"name\"]}", typeof(SchemaParseException))]
    [Arguments("{\"type\":\"enum\",\"name\":\"Test\",\"symbols\":[\"AA\",\"AA\"]}", typeof(SchemaParseException))]
    public void CanParseEnumType(string json, Type expectedException = null)
    {
        ParseAndVerifyException(json, expectedException);
    }

    [Test]
    [Arguments("{\"type\":\"array\",\"items\":\"long\"}")]
    [Arguments("{\"type\":\"array\",\"items\":{\"type\":\"enum\",\"name\":\"Test\",\"symbols\":[\"A\",\"B\"]}}")]
    [Arguments("{\"type\":\"array\"}", typeof(SchemaParseException))]
    public void CanParseArray(string json, Type expectedException = null)
    {
        ParseAndVerifyException(json, expectedException);
    }

    [Test]
    [Arguments("{\"type\":\"map\",\"values\":\"long\"}")]
    [Arguments("{\"type\":\"map\",\"values\":{\"type\":\"enum\",\"name\":\"Test\",\"symbols\":[\"A\", \"B\"]}}")]
    public void CanParseMap(string json)
    {
        AvroSchemaInfo.Parse(json);
    }

    [Test]
    [Arguments("[\"string\",\"null\",\"long\"]")]
    [Arguments("[\"string\",\"long\",\"long\"]", typeof(SchemaParseException))]
    [Arguments("[{\"type\":\"array\",\"items\":\"long\"},{\"type\":\"array\",\"items\":\"string\"}]", typeof(SchemaParseException))]
    [Arguments("{\"type\":[\"string\",\"null\",\"long\"]}")]
    public void CanParseUnion(string json, Type expectedException = null)
    {
        ParseAndVerifyException(json, expectedException);
    }

    [Test]
    [Arguments("{\"type\":\"fixed\",\"name\":\"Test\",\"size\":1}")]
    [Arguments("{\"type\":\"fixed\",\"name\":\"MyFixed\",\"namespace\":\"org.apache.hadoop.avro\",\"size\":1}")]
    [Arguments("{\"type\":\"fixed\",\"name\":\"Missing size\"}", typeof(SchemaParseException))]
    [Arguments("{\"type\":\"fixed\",\"size\":314}", typeof(SchemaParseException))]
    public void CanParseFixed(string json, Type expectedException = null)
    {
        ParseAndVerifyException(json, expectedException);
    }

    [Test]
    [Arguments("{\"type\":\"null\",\"metafield\":\"abc\"}", "null")]
    [Arguments("{\"type\":\"boolean\",\"metafield\":\"abc\"}", "boolean")]
    [Arguments("{\"type\":\"int\",\"metafield\":\"abc\"}", "int")]
    [Arguments("{\"type\":\"long\",\"metafield\":\"abc\"}", "long")]
    [Arguments("{\"type\":\"float\",\"metafield\":\"abc\"}", "float")]
    [Arguments("{\"type\":\"double\",\"metafield\":\"abc\"}", "double")]
    [Arguments("{\"type\":\"bytes\",\"metafield\":\"abc\"}", "bytes")]
    [Arguments("{\"type\":\"string\",\"metafield\":\"abc\"}", "string")]
    public async Task CanParsePrimitiveWithMetadata(string json, string type)
    {
        var schema = AvroSchemaInfo.Parse(json);

        await Assert.That(schema.ParsedSchema?.Tag.ToStringType()).IsEqualTo(type);
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
