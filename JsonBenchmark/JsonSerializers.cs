using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace JsonBenchmark
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class JsonSerializers
    {
        private AnnotatedVariant[] _annotatedVariants = Utilities.CreateAnnotatedVariants(1_00_000);
        
        [Benchmark]
        public int NewtonSoftSerializer()
        {
            var length = 0;
            foreach (var variant in _annotatedVariants)
            {
                length += JsonConvert.SerializeObject(variant).Length;
            }

            return length;
        }

        [Benchmark]
        public int Utf8JsonSerializer()
        {
            var length = 0;
            foreach (var variant in _annotatedVariants)
            {
                length += Utf8Json.JsonSerializer.ToJsonString(variant).Length;
            }

            return length;
        }
        
        [Benchmark]
        public int Utf8JsonBytes()
        {
            var length = 0;
            foreach (var variant in _annotatedVariants)
            {
                length += Utf8Json.JsonSerializer.Serialize(variant).Length;
            }

            return length;
        }

        [Benchmark]
        public int SystemTextJsonSerializer()
        {
            var length = 0;
            foreach (var variant in _annotatedVariants)
            {
                length += JsonSerializer.Serialize(variant).Length;
            }

            return length;
        }

        [Benchmark(Baseline = true)]
        public int NirvanaJsonSerializer()
        {
            var length = 0;
            foreach (var variant in _annotatedVariants)
            {
                length += variant.SerializeJson().Length;
            }

            return length;
        }
    }
}