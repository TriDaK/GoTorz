using System.Text.Json.Serialization;

namespace Gotorz.Models.PackageDTOs
{
    public class PackageApiRoom
    {
        [JsonPropertyName("roomCapacity")]
        public int RoomCapacity { get; set; }
        [JsonPropertyName("roomType")]
        public string RoomType { get; set; }
        [JsonPropertyName("checkIn")]
        public DateTime CheckIn { get; set; }
        [JsonPropertyName("checkOut")]
        public DateTime CheckOut { get; set; }
    }
}


