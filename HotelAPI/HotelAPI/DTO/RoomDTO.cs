namespace HotelAPI.DTO
{
    public class RoomDTO
    {
        // DTO - Data Tranfer Object
        // The data that will be send out of the API

        // room info
        public int RoomID { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }

        // hotel info
        public int HotelID { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public string StreetNo { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
