using Avro.Reflect;

namespace Avrolite.Benchmark.Models;

public class AvroModel
{
    [AvroField("id")]
    public int Id { get; set; }

    [AvroField("address")]
    public string? Address { get; set; }

    [AvroField("names")]
    public List<string> Names { get; set; }
}
