using Package_Api.Models;

namespace Package_Api.DTOs
{
    public class PackageCreateRequest
    {
        public List<Flight> Flights { get; set; }
        public List<AvailableRoom> Rooms { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
