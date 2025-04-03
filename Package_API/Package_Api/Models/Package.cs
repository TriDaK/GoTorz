namespace Package_Api.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public int FlightId { get; set; }
        public int HotelId { get; set; }

        public Employee Employee { get; set; }

        // Foreign keys for loading classes
        public int EmployeeId { get; set; }
    }
}
