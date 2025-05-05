using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Api.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [InverseProperty("Customer")]
        public List<Booking> Bookings { get; set; }
    }
}
