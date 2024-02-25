using AvroSchemaGenerator;
using AvroSerialize.Metadata;
using AvroSerialize.Metadata.Schemas;
using Xunit;

namespace AvroSerialize.Tests;

public class Tests
{
    [Fact]
    public void Test()
    {
        const string json = @"{ ""type"" : ""record"", ""namespace"" : ""Tutorialspoint"", ""name"" : ""Employee"", ""fields"" : [ { ""name"" : ""Name"" , ""type"" : ""string"" }, { ""name"" : ""Age"" , ""type"" : ""int"" } ] }";

        var schema = new JsonSchemaBuilder().Build(json);
    }

    [Fact]
    public void Try()
    {
        var schema = typeof(Model).GetSchema();
    }

    private class Model
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
