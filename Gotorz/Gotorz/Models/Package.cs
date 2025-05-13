using System.Text.Json.Serialization; // for JsonPropertyName

namespace Gotorz.Models
{
    public class Package
    {
        // the info we will save from the package API
        // some properties commented out until API can deliver them
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("price")]
        public string Price { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("pictures")]
        public List<Picture?> Pictures { get; set; }
        [JsonPropertyName("timeDeparture")]
        public DateTime TimeDeparture { get; set; }
        [JsonPropertyName("timeArrival")]
        public DateTime TimeArrival { get; set; }
    }
}
