using System.Text.Json.Serialization;

namespace Gotorz.Models
{
    public class ChatMessage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("packageId")]
        public int PackageId { get; set; }
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
