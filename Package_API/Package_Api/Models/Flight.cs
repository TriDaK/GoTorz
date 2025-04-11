namespace Package_Api.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Airport { get; set; }
        public DateTime Departure { get; set; }

        // Foreign key for relations
        public int PackageId { get; set; }
    }
}
