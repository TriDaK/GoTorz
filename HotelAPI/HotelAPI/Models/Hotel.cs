﻿namespace HotelAPI.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public string StreetNo { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // DB multiplicity ref
        public ICollection<Room> Rooms { get; set; }
  
    }
}
