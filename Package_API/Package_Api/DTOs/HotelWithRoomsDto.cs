﻿namespace Package_Api.DTOs
{
    public class HotelWithRoomsDto
    {
        public string Phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<RoomDto> Rooms { get; set; }
    }
}
