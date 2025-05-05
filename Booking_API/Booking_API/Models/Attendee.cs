using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Booking_Api.Models
{
    public class Attendee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public DateOnly Birthdate { get; set; }

        public Gender Gender { get; set; }

        [JsonIgnore]
        public int BookingId { get; set; }

        // [InverseProperty("Attendees")]
        public Booking Booking { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
