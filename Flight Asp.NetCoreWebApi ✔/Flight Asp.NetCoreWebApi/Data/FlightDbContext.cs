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
                    Id = 00001,
                    FlightNumber = 1234,
                    FlightStatus = "On Time",
                    DestinationFrom = "Oslo",
                    DestinationTo = "Paris",
                    TimeDeparture = new DateTime(2024, 3, 25, 16, 45, 0),
                    TimeArrival = new DateTime(2024, 3, 25, 22, 45, 0)
                },
            new Flight
            {
                Id = 00002,
                FlightNumber = 5678,
                FlightStatus = "Delayed",
                DestinationFrom = "London",
                DestinationTo = "Berlin",
                TimeDeparture = new DateTime(2024, 3, 25, 17, 30, 0),
                TimeArrival = new DateTime(2024, 3, 25, 23, 30, 0)
            },
            new Flight
            {
                Id = 00003,
                FlightNumber = 9101,
                FlightStatus = "Cancelled",
                DestinationFrom = "Madrid",
                DestinationTo = "Rome",
                TimeDeparture = new DateTime(2024, 3, 25, 18, 15, 0),
                TimeArrival = new DateTime(2024, 3, 26, 00, 15, 0)
            },
            new Flight
            {
                Id = 00004,
                FlightNumber = 1121,
                FlightStatus = "Arrived",
                DestinationFrom = "Bergen",
                DestinationTo = "Oslo",
                TimeDeparture = new DateTime(2024, 3, 25, 19, 00, 0),
                TimeArrival = new DateTime(2024, 3, 26, 01, 00, 0)
            },
            new Flight
            {
                Id = 00005,
                FlightNumber = 3141,
                FlightStatus = "On Time",
                DestinationFrom = "Paris",
                DestinationTo = "London",
                TimeDeparture = new DateTime(2024, 3, 25, 20, 30, 0),
                TimeArrival = new DateTime(2024, 3, 26, 02, 30, 0)
            }
            );
            }
            ;
        }

    }
}
