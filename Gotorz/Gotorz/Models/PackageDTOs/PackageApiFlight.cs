using System.Text.Json.Serialization;

namespace Gotorz.Models.PackageDTOs
{
    public class PackageApiFlight
    {
        // the info we will save from the flight API .json respons 
        [JsonPropertyName("flightNumber")]
        public string FlightNumber { get; set; }
        [JsonPropertyName("departure")]
        public DateTime TimeDeparture { get; set; }
    }
}
