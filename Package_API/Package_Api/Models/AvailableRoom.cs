using System.ComponentModel.DataAnnotations.Schema;

namespace Package_Api.Models
{
    public class AvailableRoom
    {
        public int Id { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        // Foreign key for relations
        public int PackageId { get; set; }
        // Foreign key for loading classes
        public int HotelId { get; set; }

        // Navigation property
        [InverseProperty("AvailableRooms")]
        public Hotel Hotel { get; set; }
        [InverseProperty("AvailableRooms")]
        public Package Package { get; set; }
    }
}
