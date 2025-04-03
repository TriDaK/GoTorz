using System.Text.Json.Serialization;

namespace Package_Api.Models
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
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
