namespace Flight_Asp.NetCoreWebApi
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string FlightStatus { get; set; }
        public string DestinationFrom { get; set; }
        public string AirportFrom { get; set; }
        public string DestinationTo { get; set; }
        public string AirportTo {  get; set; }      
        public DateTime TimeDeparture { get; set; }
        public DateTime TimeArrival { get; set; }
        public int AvailableSeats { get; set; }
        public int price { get; set; }

    }
}
