namespace Package_Api.DTOs
{
    public class PackageResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string EmployeeName { get; set; }

        public List<FlightDto> Flights { get; set; }
        public HotelWithRoomsDto Hotel { get; set; }
        public List<PictureDto> Pictures { get; set; }
    }
}
