namespace Package_Api.DTOs
{
    public class RoomDto
    {
        public int RoomCapacity { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
