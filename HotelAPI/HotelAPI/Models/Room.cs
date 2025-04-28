namespace HotelAPI.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }

        // DB multiplicity ref
        public int HotelID { get; set; }
        public Hotel Hotel { get; set; }
    }
}
