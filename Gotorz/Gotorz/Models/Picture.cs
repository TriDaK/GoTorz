using System.Text.Json.Serialization;

namespace Gotorz.Models
{
    public class Picture
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("picture")]
        public byte[] Image { get; set; }
        [JsonPropertyName("packageId")]
        public int PackageId { get; set; }
    }
}
