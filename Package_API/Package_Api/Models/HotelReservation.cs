namespace Package_Api.Models
{
    public class HotelReservation
    {
        public int Id { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Amenities { get; set; }
        public decimal Price { get; set; }

        // Foreign key for relations
        public int PackageId { get; set; }
        // Foreign key for loading classes
        public int HotelId { get; set; }

        // Navigation property
        public Hotel Hotel { get; set; }
    }
}
