using System.Text.Json.Serialization;

namespace Gotorz.Models.PackageDTOs
{
    public class PackageApiPackage
    {
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
        [JsonPropertyName("flights")]
        public List<PackageApiFlight> Flights { get; set; }

        [JsonPropertyName("employee")]
        public Employee Employee { set; get; }
    }
}
