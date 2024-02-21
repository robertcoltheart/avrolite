using AvroSchemaGenerator;
using AvroSerialize.Benchmark.Models;
using BenchmarkDotNet.Attributes;
using SolTechnology.Avro;

namespace AvroSerialize.Benchmark;

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
