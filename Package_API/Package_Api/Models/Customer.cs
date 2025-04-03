﻿namespace Package_Api.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public List<Booking> Bookings { get; set; }

        // Foreign keys for loading classes
        public int[] BookingIds { get; set; }
    }
}
