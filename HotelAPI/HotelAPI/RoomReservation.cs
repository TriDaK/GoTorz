namespace HotelAPI
{
    public class RoomReservation
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        
        // jeg ved ikke hvordan vi skal løse denne. liste? hvordan skal den se ud i DB?
        //public string Ameneties { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
    }
}
