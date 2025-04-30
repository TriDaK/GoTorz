using System.ComponentModel.DataAnnotations.Schema;

namespace Package_Api.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // The employee who created the package
        [InverseProperty("Packages")]
        public Employee Employee { get; set; }

        // Foreign keys for loading classes
        public int EmployeeId { get; set; }

        // Package is additionally connected to Pictures, Bookings, and Flights
        [InverseProperty("Package")]
        public List<Picture> Pictures { get; set; }
        [InverseProperty("Package")]
        public List<Flight> Flights { get; set; }

        [InverseProperty("Package")]
        public List<AvailableRoom> AvailableRooms { get; set; }
    }
}
