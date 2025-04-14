using System.ComponentModel.DataAnnotations.Schema;

namespace Package_Api.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Amenities { get; set; }

        [InverseProperty("Hotel")]
        public List<HotelReservation> HotelReservations { get; set; }
    }
}
