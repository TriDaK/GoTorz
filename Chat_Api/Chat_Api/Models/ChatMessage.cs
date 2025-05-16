namespace Chat_Api.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string PackageId { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
    }
}
