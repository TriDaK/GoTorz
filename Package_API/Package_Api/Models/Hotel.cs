using System.ComponentModel.DataAnnotations.Schema;

namespace Package_Api.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [InverseProperty("Hotel")]
        public List<AvailableRoom> AvailableRooms { get; set; }
    }
}
