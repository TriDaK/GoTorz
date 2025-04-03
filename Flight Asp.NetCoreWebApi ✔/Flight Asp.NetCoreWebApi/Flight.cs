namespace Flight_Asp.NetCoreWebApi
{
    public class Flight
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public string FlightStatus { get; set; }
        public string DestinationFrom { get; set; }
        public string DestinationTo { get; set; }
        public DateTime TimeDeparture { get; set; }
        public DateTime TimeArrival { get; set; }

    }
}
