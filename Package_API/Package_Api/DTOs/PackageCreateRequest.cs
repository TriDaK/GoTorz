using Package_Api.Models;

namespace Package_Api.DTOs
{
    public class PackageCreateRequest
    {
        public List<FlightDto> Flights { get; set; }
        public List<RoomDto> Rooms { get; set; }
        public HotelDto Hotel { get; set; }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
