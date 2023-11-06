using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Skymey_mongodb.Models
{
    public class Exchanges
    {
        [JsonPropertyName("_id")]
        public ObjectId _id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Volume24h")]
        public double Volume24h { get; set; }
        [JsonPropertyName("Trades")]
        public int Trades { get; set; }
        [JsonPropertyName("Pairs")]
        public int Pairs { get; set; }
        [JsonPropertyName("Type")]
        public string Type { get; set; }
        [JsonPropertyName("Blockchain")]
        public string Blockchain { get; set; }
        [JsonPropertyName("ScraperActive")]
        public bool ScraperActive { get; set; }
        public DateTime Update { get; set; }
    }
}
