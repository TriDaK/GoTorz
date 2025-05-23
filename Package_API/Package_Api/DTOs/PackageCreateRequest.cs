using Package_Api.Models;

namespace Package_Api.DTOs
{
    public class PackageCreateRequest
    {
        public List<FlightDto> Flights { get; set; }
        public List<RoomDto> Rooms { get; set; }
        public HotelDto Hotel { get; set; }

        public EmployeePackageDto Employee { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
