using AvroSchemaGenerator;
using Avrocado.Benchmark.Models;
using BenchmarkDotNet.Attributes;
using SolTechnology.Avro;

namespace Avrocado.Benchmark;

public class SerializeBenchmark
{
    [Benchmark]
    public string UseAvroConvert()
    {
        return AvroConvert.GenerateSchema(typeof(AvroModel));
    }

    [Benchmark]
    public string UseAvroSchemaGenerator()
    {
        return typeof(AvroModel).GetSchema();
    }
}
