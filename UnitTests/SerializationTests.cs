using System;
using System.Text;
using JsonBenchmark;
using Newtonsoft.Json;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace UnitTests
{
    public class SerializationTests
    {
        [Fact]
        public void Test1()
        {
            var variant = AnnotatedVariant.Create();

            var nirvanaJson = variant.SerializeJson();
            var newtonsoftJson = JsonConvert.SerializeObject(variant);
            var utf8Json = Utf8Json.JsonSerializer.ToJsonString(variant);
            var utf8Bytes = Utf8Json.JsonSerializer.Serialize(variant);
            var systemJson = JsonSerializer.Serialize(variant);
            
            Assert.Equal(nirvanaJson, newtonsoftJson);
            Assert.Equal(nirvanaJson, utf8Json);
            Assert.Equal(nirvanaJson, Encoding.UTF8.GetString(utf8Bytes));
            Assert.Equal(nirvanaJson, systemJson);

        }
    }
}