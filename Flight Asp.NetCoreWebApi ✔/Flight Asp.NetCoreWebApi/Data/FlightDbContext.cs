using Microsoft.EntityFrameworkCore;

namespace Flight_Asp.NetCoreWebApi.Data
{
    public class FlightDbContext(DbContextOptions<FlightDbContext> options) : DbContext(options)
    {
        public DbSet<Flight> Flights => Set<Flight>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Flight>().HasData(
                new Flight
                {
                    Id = 1,
                    FlightNumber = "1234",
                    FlightStatus = "On Time",
                    DestinationFrom = "Oslo",
                    AirportFrom = "OSL", // Add AirportFrom
                    DestinationTo = "Paris",
                    AirportTo = "CDG",   // Add AirportTo
                    TimeDeparture = new DateTime(2024, 3, 25, 16, 45, 0),
                    TimeArrival = new DateTime(2024, 3, 25, 22, 45, 0),
                    AvailableSeats = 150, // Add AvailableSeats
                    price = 200          // Add price
                },
                new Flight
                {
                    Id = 2,
                    FlightNumber = "5678",
                    FlightStatus = "Delayed",
                    DestinationFrom = "London",
                    AirportFrom = "LHR",
                    DestinationTo = "Berlin",
                    AirportTo = "BER",
                    TimeDeparture = new DateTime(2024, 3, 25, 17, 30, 0),
                    TimeArrival = new DateTime(2024, 3, 25, 23, 30, 0),
                    AvailableSeats = 120,
                    price = 180
                },
                new Flight
                {
                    Id = 3,
                    FlightNumber = "9101",
                    FlightStatus = "Cancelled",
                    DestinationFrom = "Madrid",
                    AirportFrom = "MAD",
                    DestinationTo = "Rome",
                    AirportTo = "FCO",
                    TimeDeparture = new DateTime(2024, 3, 25, 18, 15, 0),
                    TimeArrival = new DateTime(2024, 3, 26, 00, 15, 0),
                    AvailableSeats = 100,
                    price = 150
                },
                new Flight
                {
                    Id = 4,
                    FlightNumber = "1121",
                    FlightStatus = "Arrived",
                    DestinationFrom = "Bergen",
                    AirportFrom = "BGO",
                    DestinationTo = "Oslo",
                    AirportTo = "OSL",
                    TimeDeparture = new DateTime(2024, 3, 25, 19, 00, 0),
                    TimeArrival = new DateTime(2024, 3, 26, 01, 00, 0),
                    AvailableSeats = 130,
                    price = 170
                },
                new Flight
                {
                    Id = 5,
                    FlightNumber = "3141",
                    FlightStatus = "On Time",
                    DestinationFrom = "Paris",
                    AirportFrom = "CDG",
                    DestinationTo = "London",
                    AirportTo = "LHR",
                    TimeDeparture = new DateTime(2024, 3, 25, 20, 30, 0),
                    TimeArrival = new DateTime(2024, 3, 26, 02, 30, 0),
                    AvailableSeats = 140,
                    price = 190
                }
            );
            }
        }
    }
}
