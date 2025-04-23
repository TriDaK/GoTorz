namespace HotelAPI
{
    public class Hotel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public string StreetNo { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        // jeg ved ikke hvordan vi skal løse denne. liste? hvordan skal den se ud i DB?
        //public string Ameneties { get; set; }
    }
}
