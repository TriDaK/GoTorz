using System.Text.Json.Serialization;

namespace Gotorz.Models.PackageDTOs
{
    public class PackageApiPackage
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("flights")]
        public List<PackageApiFlight> Flights { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonPropertyName("hotel")]
        public PackageApiHotel Hotel { get; set; }

        [JsonPropertyName("rooms")]
        public List<PackageApiRoom> Rooms { get; set; }
    }
}
