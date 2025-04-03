using System.Text.Json.Serialization;

namespace Gotorz.Models
{
    public class Flight
    {
        // the info we will save from the flight API
        // some properties commented out until API can deliver them

        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("flightNumber")]
        public string FlightNumber { get; set; }
        [JsonPropertyName("flightStatus")]
        public string FlightStatus { get; set; }
        [JsonPropertyName("destinationFrom")]
        public string DestinationFrom { get; set; }
        //[JsonPropertyName("...")]
        // public string AirportFrom { get; set; }
        [JsonPropertyName("destinationTo")]
        public string DestinationTo { get; set; }
        // [JsonPropertyName("...")]
        // public string AirportTo { get; set; }
        [JsonPropertyName("timeDeparture")]
        public DateTime TimeDeparture { get; set; }
        [JsonPropertyName("timeArrival")]
        public DateTime TimeArrival { get; set; }
        //[JsonPropertyName("...")]
        // public int AvailableSeats { get; set; } // Comes from API, but shall not be saved to the DB
        //[JsonPropertyName("...")]

        // public int Price { get; set; }

    }
}
