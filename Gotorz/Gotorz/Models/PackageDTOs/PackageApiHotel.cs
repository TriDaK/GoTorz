using System.Text.Json.Serialization;

namespace Gotorz.Models.PackageDTOs
{
    public class PackageApiHotel
    {
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}

