using System.Text.Json.Serialization;

namespace Gotorz.Models
{
    public class Hotel
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("streetName")]
        public string StreetName { get; set; }

        [JsonPropertyName("streetNo")]
        public string StreetNo { get; set; }

        [JsonPropertyName("zipcode")]
        public int Zipcode { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }

        [JsonPropertyName("checkIn")]
        public DateTime CheckIn { get; set; }

        [JsonPropertyName("checkOut")]
        public DateTime CheckOut { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        // DB multiplicity ref
        [JsonPropertyName("hotelID")]
        public int HotelID { get; set; }
    }
}
