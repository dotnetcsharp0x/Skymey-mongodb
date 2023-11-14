using BenchmarkDotNet.Attributes;
using MongoDB.Driver;
using Skymey_mongodb.Data;

namespace Skymey_mongodb
{
    public class SkymeyBenchmark
    {
        private static MongoClient _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
        private ApplicationContext _db = ApplicationContext.Create(_mongoClient.GetDatabase("skymey"));

        public class Exchanges
        {
            public string Name { get; set; }
        }


        [Benchmark]
        public HashSet<Exchanges> GetPricesFromMongoHashSet()
        {
            return new HashSet<Exchanges> { new Exchanges { Name = "Binance" } };
        }

        [Benchmark]
        public List<Exchanges> GetPricesFromMongoList()
        {
            return new List<Exchanges> { new Exchanges { Name = "Binance" } };
        }
    }
}
