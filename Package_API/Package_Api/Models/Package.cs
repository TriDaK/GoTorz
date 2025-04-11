namespace Package_Api.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int FlightId { get; set; }
        public int HotelReservationId { get; set; }
        // The employee who created the package
        public Employee Employee { get; set; }

        // Foreign keys for loading classes
        public int EmployeeId { get; set; }

        // Package is additionally connected to Pictures, Bookings, and Flights
        public List<Picture> Pictures { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Flight> Flights { get; set; }
    }
}
