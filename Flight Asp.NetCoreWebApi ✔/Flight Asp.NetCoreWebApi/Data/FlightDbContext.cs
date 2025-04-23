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
                    Price = 200          // Add price
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
                    Price = 180
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
                    Price = 150
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
                    Price = 170
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
                    Price = 190
                } ,
                 new Flight { Id = 2, AirportFrom = "CPH", AirportTo = "LHR", AvailableSeats = 120, DestinationFrom = "Copenhagen", DestinationTo = "London", FlightNumber = "5678", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 20, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 17, 0, 0), Price = 250 },
    new Flight { Id = 3, AirportFrom = "AMS", AirportTo = "BCN", AvailableSeats = 180, DestinationFrom = "Amsterdam", DestinationTo = "Barcelona", FlightNumber = "9101", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 23, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 18, 30, 0), Price = 180 },
    new Flight { Id = 4, AirportFrom = "FRA", AirportTo = "JFK", AvailableSeats = 200, DestinationFrom = "Frankfurt", DestinationTo = "New York", FlightNumber = "1121", FlightStatus = "Cancelled", TimeArrival = new DateTime(2024, 3, 25, 21, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 16, 0, 0), Price = 300 },
    new Flight { Id = 5, AirportFrom = "MAD", AirportTo = "ROM", AvailableSeats = 130, DestinationFrom = "Madrid", DestinationTo = "Rome", FlightNumber = "3141", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 22, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 17, 45, 0), Price = 220 },
    new Flight { Id = 6, AirportFrom = "IST", AirportTo = "DXB", AvailableSeats = 220, DestinationFrom = "Istanbul", DestinationTo = "Dubai", FlightNumber = "5161", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 23, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 19, 0, 0), Price = 280 },
    new Flight { Id = 7, AirportFrom = "SVO", AirportTo = "PEK", AvailableSeats = 190, DestinationFrom = "Moscow", DestinationTo = "Beijing", FlightNumber = "7282", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 21, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 15, 30, 0), Price = 350 },
    new Flight { Id = 8, AirportFrom = "DME", AirportTo = "HKG", AvailableSeats = 160, DestinationFrom = "Moscow", DestinationTo = "Hong Kong", FlightNumber = "9303", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 22, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 16, 15, 0), Price = 320 },
    new Flight { Id = 9, AirportFrom = "ARN", AirportTo = "BKK", AvailableSeats = 170, DestinationFrom = "Stockholm", DestinationTo = "Bangkok", FlightNumber = "1414", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 23, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 17, 30, 0), Price = 300 },
    new Flight { Id = 10, AirportFrom = "HEL", AirportTo = "SIN", AvailableSeats = 180, DestinationFrom = "Helsinki", DestinationTo = "Singapore", FlightNumber = "2525", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 23, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 18, 0, 0), Price = 330 },
    new Flight { Id = 11, AirportFrom = "ZRH", AirportTo = "SYD", AvailableSeats = 210, DestinationFrom = "Zurich", DestinationTo = "Sydney", FlightNumber = "3636", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 26, 8, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 19, 30, 0), Price = 400 },
    new Flight { Id = 12, AirportFrom = "BRU", AirportTo = "MEL", AvailableSeats = 200, DestinationFrom = "Brussels", DestinationTo = "Melbourne", FlightNumber = "4747", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 26, 9, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 20, 0, 0), Price = 380 },
    new Flight { Id = 13, AirportFrom = "VIE", AirportTo = "AKL", AvailableSeats = 190, DestinationFrom = "Vienna", DestinationTo = "Auckland", FlightNumber = "5858", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 26, 10, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 21, 0, 0), Price = 420 },
    new Flight { Id = 14, AirportFrom = "PRG", AirportTo = "NRT", AvailableSeats = 170, DestinationFrom = "Prague", DestinationTo = "Tokyo", FlightNumber = "6969", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 26, 7, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 18, 30, 0), Price = 370 },
    new Flight { Id = 15, AirportFrom = "WAW", AirportTo = "ICN", AvailableSeats = 180, DestinationFrom = "Warsaw", DestinationTo = "Seoul", FlightNumber = "8080", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 26, 6, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 17, 45, 0), Price = 360 },
    new Flight { Id = 16, AirportFrom = "BUD", AirportTo = "LAX", AvailableSeats = 220, DestinationFrom = "Budapest", DestinationTo = "Los Angeles", FlightNumber = "1919", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 20, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 14, 30, 0), Price = 450 },
    new Flight { Id = 17, AirportFrom = "LIS", AirportTo = "SFO", AvailableSeats = 210, DestinationFrom = "Lisbon", DestinationTo = "San Francisco", FlightNumber = "2020", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 19, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 13, 45, 0), Price = 430 },
    new Flight { Id = 18, AirportFrom = "ATH", AirportTo = "YVR", AvailableSeats = 200, DestinationFrom = "Athens", DestinationTo = "Vancouver", FlightNumber = "3131", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 19, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 13, 0, 0), Price = 410 },
    new Flight { Id = 19, AirportFrom = "DUB", AirportTo = "YYZ", AvailableSeats = 190, DestinationFrom = "Dublin", DestinationTo = "Toronto", FlightNumber = "4242", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 18, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 12, 30, 0), Price = 390 },
    new Flight { Id = 20, AirportFrom = "EDI", AirportTo = "YUL", AvailableSeats = 180, DestinationFrom = "Edinburgh", DestinationTo = "Montreal", FlightNumber = "5353", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 18, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 12, 15, 0), Price = 380 },
    new Flight { Id = 21, AirportFrom = "MAN", AirportTo = "MIA", AvailableSeats = 220, DestinationFrom = "Manchester", DestinationTo = "Miami", FlightNumber = "6464", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 22, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 16, 0, 0), Price = 440 },
    new Flight { Id = 22, AirportFrom = "BHX", AirportTo = "ATL", AvailableSeats = 210, DestinationFrom = "Birmingham", DestinationTo = "Atlanta", FlightNumber = "7575", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 21, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 15, 45, 0), Price = 420 },
    new Flight { Id = 23, AirportFrom = "GLA", AirportTo = "ORD", AvailableSeats = 200, DestinationFrom = "Glasgow", DestinationTo = "Chicago", FlightNumber = "8686", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 21, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 15, 30, 0), Price = 410 },
    new Flight { Id = 24, AirportFrom = "NCL", AirportTo = "DFW", AvailableSeats = 190, DestinationFrom = "Newcastle", DestinationTo = "Dallas", FlightNumber = "9797", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 21, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 15, 15, 0), Price = 400 },
    new Flight { Id = 25, AirportFrom = "BRS", AirportTo = "DEN", AvailableSeats = 180, DestinationFrom = "Bristol", DestinationTo = "Denver", FlightNumber = "1080", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 21, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 15, 0, 0), Price = 390 },
    new Flight { Id = 26, AirportFrom = "LTN", AirportTo = "SEA", AvailableSeats = 220, DestinationFrom = "London", DestinationTo = "Seattle", FlightNumber = "2191", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 20, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 14, 45, 0), Price = 430 },
    new Flight { Id = 27, AirportFrom = "STN", AirportTo = "PHX", AvailableSeats = 210, DestinationFrom = "London", DestinationTo = "Phoenix", FlightNumber = "3202", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 20, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 14, 30, 0), Price = 420 },
    new Flight { Id = 28, AirportFrom = "SEN", AirportTo = "SJC", AvailableSeats = 200, DestinationFrom = "London", DestinationTo = "San Jose", FlightNumber = "4313", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 20, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 14, 15, 0), Price = 410 },
    new Flight { Id = 29, AirportFrom = "BOH", AirportTo = "SAN", AvailableSeats = 190, DestinationFrom = "Bournemouth", DestinationTo = "San Diego", FlightNumber = "5424", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 20, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 14, 0, 0), Price = 400 },
    new Flight { Id = 30, AirportFrom = "LPL", AirportTo = "LAS", AvailableSeats = 180, DestinationFrom = "Liverpool", DestinationTo = "Las Vegas", FlightNumber = "6535", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 19, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 13, 45, 0), Price = 390 },
    new Flight { Id = 31, AirportFrom = "BFS", AirportTo = "SFO", AvailableSeats = 220, DestinationFrom = "Belfast", DestinationTo = "San Francisco", FlightNumber = "7646", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 19, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 13, 30, 0), Price = 440 },
    new Flight { Id = 32, AirportFrom = "ORK", AirportTo = "LAX", AvailableSeats = 210, DestinationFrom = "Cork", DestinationTo = "Los Angeles", FlightNumber = "8757", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 19, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 13, 15, 0), Price = 430 },
    new Flight { Id = 33, AirportFrom = "SNN", AirportTo = "JFK", AvailableSeats = 200, DestinationFrom = "Shannon", DestinationTo = "New York", FlightNumber = "9868", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 19, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 13, 0, 0), Price = 420 },
    new Flight { Id = 34, AirportFrom = "DUB", AirportTo = "MIA", AvailableSeats = 190, DestinationFrom = "Dublin", DestinationTo = "Miami", FlightNumber = "1099", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 18, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 12, 45, 0), Price = 410 },
    new Flight { Id = 35, AirportFrom = "BHD", AirportTo = "ATL", AvailableSeats = 180, DestinationFrom = "Belfast", DestinationTo = "Atlanta", FlightNumber = "2110", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 18, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 12, 30, 0), Price = 400 },
    new Flight { Id = 36, AirportFrom = "KIR", AirportTo = "ORD", AvailableSeats = 220, DestinationFrom = "Kerry", DestinationTo = "Chicago", FlightNumber = "3221", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 18, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 12, 15, 0), Price = 430 },
    new Flight { Id = 37, AirportFrom = "NOC", AirportTo = "DFW", AvailableSeats = 210, DestinationFrom = "Knock", DestinationTo = "Dallas", FlightNumber = "4332", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 18, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 12, 0, 0), Price = 420 },
    new Flight { Id = 38, AirportFrom = "CFN", AirportTo = "DEN", AvailableSeats = 200, DestinationFrom = "Donegal", DestinationTo = "Denver", FlightNumber = "5443", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 17, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 11, 45, 0), Price = 410 },
    new Flight { Id = 39, AirportFrom = "NNR", AirportTo = "SEA", AvailableSeats = 190, DestinationFrom = "Connacht", DestinationTo = "Seattle", FlightNumber = "6554", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 17, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 11, 30, 0), Price = 400 },
    new Flight { Id = 40, AirportFrom = "GWY", AirportTo = "PHX", AvailableSeats = 180, DestinationFrom = "Galway", DestinationTo = "Phoenix", FlightNumber = "7665", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 17, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 11, 15, 0), Price = 390 },
    new Flight { Id = 41, AirportFrom = "WAT", AirportTo = "SJC", AvailableSeats = 220, DestinationFrom = "Waterford", DestinationTo = "San Jose", FlightNumber = "8776", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 17, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 11, 0, 0), Price = 430 },
    new Flight { Id = 42, AirportFrom = "SXL", AirportTo = "SAN", AvailableSeats = 210, DestinationFrom = "Sligo", DestinationTo = "San Diego", FlightNumber = "9887", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 16, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 10, 45, 0), Price = 420 },
    new Flight { Id = 43, AirportFrom = "LKY", AirportTo = "LAS", AvailableSeats = 200, DestinationFrom = "Limerick", DestinationTo = "Las Vegas", FlightNumber = "1098", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 16, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 10, 30, 0), Price = 410 },
    new Flight { Id = 44, AirportFrom = "SNN", AirportTo = "SFO", AvailableSeats = 190, DestinationFrom = "Shannon", DestinationTo = "San Francisco", FlightNumber = "2109", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 16, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 10, 15, 0), Price = 400 },
    new Flight { Id = 45, AirportFrom = "DUB", AirportTo = "LAX", AvailableSeats = 180, DestinationFrom = "Dublin", DestinationTo = "Los Angeles", FlightNumber = "3210", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 16, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 10, 0, 0), Price = 410 },
    new Flight { Id = 46, AirportFrom = "ORK", AirportTo = "JFK", AvailableSeats = 220, DestinationFrom = "Cork", DestinationTo = "New York", FlightNumber = "4321", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 15, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 9, 45, 0), Price = 420 },
    new Flight { Id = 47, AirportFrom = "BHD", AirportTo = "MIA", AvailableSeats = 210, DestinationFrom = "Belfast", DestinationTo = "Miami", FlightNumber = "5432", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 15, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 9, 30, 0), Price = 410 },
    new Flight { Id = 48, AirportFrom = "KIR", AirportTo = "ATL", AvailableSeats = 200, DestinationFrom = "Kerry", DestinationTo = "Atlanta", FlightNumber = "6543", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 15, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 9, 15, 0), Price = 400 },
    new Flight { Id = 49, AirportFrom = "NOC", AirportTo = "ORD", AvailableSeats = 190, DestinationFrom = "Knock", DestinationTo = "Chicago", FlightNumber = "7654", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 15, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 9, 0, 0), Price = 390 },
    new Flight { Id = 50, AirportFrom = "CFN", AirportTo = "DFW", AvailableSeats = 180, DestinationFrom = "Donegal", DestinationTo = "Dallas", FlightNumber = "8765", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 14, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 8, 45, 0), Price = 400 },
    new Flight { Id = 51, AirportFrom = "NNR", AirportTo = "DEN", AvailableSeats = 220, DestinationFrom = "Connacht", DestinationTo = "Denver", FlightNumber = "9876", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 14, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 8, 30, 0), Price = 410 },
    new Flight { Id = 52, AirportFrom = "GWY", AirportTo = "SEA", AvailableSeats = 210, DestinationFrom = "Galway", DestinationTo = "Seattle", FlightNumber = "1097", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 14, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 8, 15, 0), Price = 420 },
    new Flight { Id = 53, AirportFrom = "WAT", AirportTo = "PHX", AvailableSeats = 200, DestinationFrom = "Waterford", DestinationTo = "Phoenix", FlightNumber = "2108", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 14, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 8, 0, 0), Price = 410 },
    new Flight { Id = 54, AirportFrom = "SXL", AirportTo = "SJC", AvailableSeats = 190, DestinationFrom = "Sligo", DestinationTo = "San Jose", FlightNumber = "3219", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 13, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 7, 45, 0), Price = 400 },
    new Flight { Id = 55, AirportFrom = "LKY", AirportTo = "SAN", AvailableSeats = 180, DestinationFrom = "Limerick", DestinationTo = "San Diego", FlightNumber = "4320", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 13, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 7, 30, 0), Price = 390 },
    new Flight { Id = 56, AirportFrom = "SNN", AirportTo = "LAS", AvailableSeats = 220, DestinationFrom = "Shannon", DestinationTo = "Las Vegas", FlightNumber = "5431", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 13, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 7, 15, 0), Price = 420 },
    new Flight { Id = 57, AirportFrom = "DUB", AirportTo = "SFO", AvailableSeats = 210, DestinationFrom = "Dublin", DestinationTo = "San Francisco", FlightNumber = "6542", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 13, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 7, 0, 0), Price = 410 },
    new Flight { Id = 58, AirportFrom = "BHD", AirportTo = "LAX", AvailableSeats = 200, DestinationFrom = "Belfast", DestinationTo = "Los Angeles", FlightNumber = "7653", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 12, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 6, 45, 0), Price = 400 },
    new Flight { Id = 59, AirportFrom = "KIR", AirportTo = "JFK", AvailableSeats = 190, DestinationFrom = "Kerry", DestinationTo = "New York", FlightNumber = "8764", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 12, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 6, 30, 0), Price = 410 },
    new Flight { Id = 60, AirportFrom = "NOC", AirportTo = "MIA", AvailableSeats = 180, DestinationFrom = "Knock", DestinationTo = "Miami", FlightNumber = "9875", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 12, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 6, 15, 0), Price = 400 },
    new Flight { Id = 61, AirportFrom = "CFN", AirportTo = "ATL", AvailableSeats = 220, DestinationFrom = "Donegal", DestinationTo = "Atlanta", FlightNumber = "1096", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 12, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 6, 0, 0), Price = 420 },
    new Flight { Id = 62, AirportFrom = "NNR", AirportTo = "ORD", AvailableSeats = 210, DestinationFrom = "Connacht", DestinationTo = "Chicago", FlightNumber = "2107", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 11, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 5, 45, 0), Price = 410 },
    new Flight { Id = 63, AirportFrom = "GWY", AirportTo = "DFW", AvailableSeats = 200, DestinationFrom = "Galway", DestinationTo = "Dallas", FlightNumber = "3218", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 11, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 5, 30, 0), Price = 400 },
    new Flight { Id = 64, AirportFrom = "WAT", AirportTo = "DEN", AvailableSeats = 190, DestinationFrom = "Waterford", DestinationTo = "Denver", FlightNumber = "4329", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 11, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 5, 15, 0), Price = 410 },
    new Flight { Id = 65, AirportFrom = "SXL", AirportTo = "SEA", AvailableSeats = 180, DestinationFrom = "Sligo", DestinationTo = "Seattle", FlightNumber = "5430", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 11, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 5, 0, 0), Price = 400 },
    new Flight { Id = 66, AirportFrom = "LKY", AirportTo = "PHX", AvailableSeats = 220, DestinationFrom = "Limerick", DestinationTo = "Phoenix", FlightNumber = "6541", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 10, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 4, 45, 0), Price = 420 },
    new Flight { Id = 67, AirportFrom = "SNN", AirportTo = "SJC", AvailableSeats = 210, DestinationFrom = "Shannon", DestinationTo = "San Jose", FlightNumber = "7652", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 10, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 4, 30, 0), Price = 410 },
    new Flight { Id = 68, AirportFrom = "DUB", AirportTo = "SAN", AvailableSeats = 200, DestinationFrom = "Dublin", DestinationTo = "San Diego", FlightNumber = "8763", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 10, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 4, 15, 0), Price = 400 },
    new Flight { Id = 69, AirportFrom = "BHD", AirportTo = "LAS", AvailableSeats = 190, DestinationFrom = "Belfast", DestinationTo = "Las Vegas", FlightNumber = "9874", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 10, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 4, 0, 0), Price = 410 },
    new Flight { Id = 70, AirportFrom = "KIR", AirportTo = "SFO", AvailableSeats = 180, DestinationFrom = "Kerry", DestinationTo = "San Francisco", FlightNumber = "1095", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 9, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 3, 45, 0), Price = 400 },
    new Flight { Id = 71, AirportFrom = "NOC", AirportTo = "LAX", AvailableSeats = 220, DestinationFrom = "Knock", DestinationTo = "Los Angeles", FlightNumber = "2106", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 9, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 3, 30, 0), Price = 420 },
    new Flight { Id = 72, AirportFrom = "CFN", AirportTo = "JFK", AvailableSeats = 210, DestinationFrom = "Donegal", DestinationTo = "New York", FlightNumber = "3217", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 9, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 3, 15, 0), Price = 410 },
    new Flight { Id = 73, AirportFrom = "NNR", AirportTo = "MIA", AvailableSeats = 200, DestinationFrom = "Connacht", DestinationTo = "Miami", FlightNumber = "4328", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 9, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 3, 0, 0), Price = 400 },
    new Flight { Id = 74, AirportFrom = "GWY", AirportTo = "ATL", AvailableSeats = 190, DestinationFrom = "Galway", DestinationTo = "Atlanta", FlightNumber = "5439", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 8, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 2, 45, 0), Price = 410 },
    new Flight { Id = 75, AirportFrom = "SXL", AirportTo = "ORD", AvailableSeats = 180, DestinationFrom = "Sligo", DestinationTo = "Chicago", FlightNumber = "6540", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 8, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 2, 30, 0), Price = 400 },
    new Flight { Id = 76, AirportFrom = "LKY", AirportTo = "DFW", AvailableSeats = 220, DestinationFrom = "Limerick", DestinationTo = "Dallas", FlightNumber = "7651", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 8, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 2, 15, 0), Price = 420 },
    new Flight { Id = 77, AirportFrom = "SNN", AirportTo = "DEN", AvailableSeats = 210, DestinationFrom = "Shannon", DestinationTo = "Denver", FlightNumber = "8762", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 8, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 2, 0, 0), Price = 410 },
    new Flight { Id = 78, AirportFrom = "DUB", AirportTo = "SEA", AvailableSeats = 200, DestinationFrom = "Dublin", DestinationTo = "Seattle", FlightNumber = "9873", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 7, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 1, 45, 0), Price = 400 },
    new Flight { Id = 79, AirportFrom = "BHD", AirportTo = "PHX", AvailableSeats = 190, DestinationFrom = "Belfast", DestinationTo = "Phoenix", FlightNumber = "1094", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 7, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 1, 30, 0), Price = 410 },
    new Flight { Id = 80, AirportFrom = "KIR", AirportTo = "SJC", AvailableSeats = 180, DestinationFrom = "Kerry", DestinationTo = "San Jose", FlightNumber = "2105", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 7, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 1, 15, 0), Price = 400 },
    new Flight { Id = 81, AirportFrom = "NOC", AirportTo = "SAN", AvailableSeats = 220, DestinationFrom = "Knock", DestinationTo = "San Diego", FlightNumber = "3216", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 7, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 1, 0, 0), Price = 420 },
    new Flight { Id = 82, AirportFrom = "CFN", AirportTo = "LAS", AvailableSeats = 210, DestinationFrom = "Donegal", DestinationTo = "Las Vegas", FlightNumber = "4327", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 6, 45, 0), TimeDeparture = new DateTime(2024, 3, 25, 0, 45, 0), Price = 410 },
    new Flight { Id = 83, AirportFrom = "NNR", AirportTo = "SFO", AvailableSeats = 200, DestinationFrom = "Connacht", DestinationTo = "San Francisco", FlightNumber = "5438", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 6, 30, 0), TimeDeparture = new DateTime(2024, 3, 25, 0, 30, 0), Price = 400 },
    new Flight { Id = 84, AirportFrom = "GWY", AirportTo = "LAX", AvailableSeats = 190, DestinationFrom = "Galway", DestinationTo = "Los Angeles", FlightNumber = "6539", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 6, 15, 0), TimeDeparture = new DateTime(2024, 3, 25, 0, 15, 0), Price = 410 },
    new Flight { Id = 85, AirportFrom = "SXL", AirportTo = "JFK", AvailableSeats = 180, DestinationFrom = "Sligo", DestinationTo = "New York", FlightNumber = "7650", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 6, 0, 0), TimeDeparture = new DateTime(2024, 3, 25, 0, 0, 0), Price = 400 },
    new Flight { Id = 86, AirportFrom = "LKY", AirportTo = "MIA", AvailableSeats = 220, DestinationFrom = "Limerick", DestinationTo = "Miami", FlightNumber = "8761", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 5, 45, 0), TimeDeparture = new DateTime(2024, 3, 24, 23, 45, 0), Price = 420 },
    new Flight { Id = 87, AirportFrom = "SNN", AirportTo = "ATL", AvailableSeats = 210, DestinationFrom = "Shannon", DestinationTo = "Atlanta", FlightNumber = "9872", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 5, 30, 0), TimeDeparture = new DateTime(2024, 3, 24, 23, 30, 0), Price = 410 },
    new Flight { Id = 88, AirportFrom = "DUB", AirportTo = "ORD", AvailableSeats = 200, DestinationFrom = "Dublin", DestinationTo = "Chicago", FlightNumber = "1093", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 5, 15, 0), TimeDeparture = new DateTime(2024, 3, 24, 23, 15, 0), Price = 400 },
    new Flight { Id = 89, AirportFrom = "BHD", AirportTo = "DFW", AvailableSeats = 190, DestinationFrom = "Belfast", DestinationTo = "Dallas", FlightNumber = "2104", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 5, 0, 0), TimeDeparture = new DateTime(2024, 3, 24, 23, 0, 0), Price = 410 },
    new Flight { Id = 90, AirportFrom = "KIR", AirportTo = "DEN", AvailableSeats = 180, DestinationFrom = "Kerry", DestinationTo = "Denver", FlightNumber = "3215", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 4, 45, 0), TimeDeparture = new DateTime(2024, 3, 24, 22, 45, 0), Price = 400 },
    new Flight { Id = 91, AirportFrom = "NOC", AirportTo = "SEA", AvailableSeats = 220, DestinationFrom = "Knock", DestinationTo = "Seattle", FlightNumber = "4326", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 4, 30, 0), TimeDeparture = new DateTime(2024, 3, 24, 22, 30, 0), Price = 420 },
    new Flight { Id = 92, AirportFrom = "CFN", AirportTo = "PHX", AvailableSeats = 210, DestinationFrom = "Donegal", DestinationTo = "Phoenix", FlightNumber = "5437", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 4, 15, 0), TimeDeparture = new DateTime(2024, 3, 24, 22, 15, 0), Price = 410 },
    new Flight { Id = 93, AirportFrom = "NNR", AirportTo = "SJC", AvailableSeats = 200, DestinationFrom = "Connacht", DestinationTo = "San Jose", FlightNumber = "6538", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 4, 0, 0), TimeDeparture = new DateTime(2024, 3, 24, 22, 0, 0), Price = 400 },
    new Flight { Id = 94, AirportFrom = "GWY", AirportTo = "SAN", AvailableSeats = 190, DestinationFrom = "Galway", DestinationTo = "San Diego", FlightNumber = "7649", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 3, 45, 0), TimeDeparture = new DateTime(2024, 3, 24, 21, 45, 0), Price = 410 },
    new Flight { Id = 95, AirportFrom = "SXL", AirportTo = "LAS", AvailableSeats = 180, DestinationFrom = "Sligo", DestinationTo = "Las Vegas", FlightNumber = "8760", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 3, 30, 0), TimeDeparture = new DateTime(2024, 3, 24, 21, 30, 0), Price = 400 },
    new Flight { Id = 96, AirportFrom = "LKY", AirportTo = "SFO", AvailableSeats = 220, DestinationFrom = "Limerick", DestinationTo = "San Francisco", FlightNumber = "9871", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 3, 15, 0), TimeDeparture = new DateTime(2024, 3, 24, 21, 15, 0), Price = 420 },
    new Flight { Id = 97, AirportFrom = "SNN", AirportTo = "LAX", AvailableSeats = 210, DestinationFrom = "Shannon", DestinationTo = "Los Angeles", FlightNumber = "1092", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 3, 0, 0), TimeDeparture = new DateTime(2024, 3, 24, 21, 0, 0), Price = 410 },
    new Flight { Id = 98, AirportFrom = "DUB", AirportTo = "JFK", AvailableSeats = 200, DestinationFrom = "Dublin", DestinationTo = "New York", FlightNumber = "2103", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 2, 45, 0), TimeDeparture = new DateTime(2024, 3, 24, 20, 45, 0), Price = 400 },
    new Flight { Id = 99, AirportFrom = "BHD", AirportTo = "MIA", AvailableSeats = 190, DestinationFrom = "Belfast", DestinationTo = "Miami", FlightNumber = "3214", FlightStatus = "Delayed", TimeArrival = new DateTime(2024, 3, 25, 2, 30, 0), TimeDeparture = new DateTime(2024, 3, 24, 20, 30, 0), Price = 410 },
    new Flight { Id = 100, AirportFrom = "KIR", AirportTo = "ATL", AvailableSeats = 180, DestinationFrom = "Kerry", DestinationTo = "Atlanta", FlightNumber = "4325", FlightStatus = "On Time", TimeArrival = new DateTime(2024, 3, 25, 2, 15, 0), TimeDeparture = new DateTime(2024, 3, 24, 20, 15, 0), Price = 400 }
            );
            }
        }
    }
}
