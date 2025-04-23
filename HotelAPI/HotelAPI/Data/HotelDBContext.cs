using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Data
{
    public class HotelDBContext(DbContextOptions<HotelDBContext> options) : DbContext(options)
    {
        public DbSet<Hotel> Hotels => Set<Hotel>();
        public DbSet<Room> Rooms => Set<Room>();

        // Dummy data
        //////// kan den på DB niveau se sammenhængene imellem de værelser der er og de hoteller de tilhører????????????????? 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Eiffel Hotel",
                    StreetName = "Rue de Paris",
                    StreetNo = "10",
                    Zipcode = 75001,
                    City = "Paris",
                    Country = "France",
                    Email = "eiffel@hotel.com",
                    Phone = "+33 123456789"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Louvre Inn",
                    StreetName = "Rue de Louvre",
                    StreetNo = "22B",
                    Zipcode = 75002,
                    City = "Paris",
                    Country = "France",
                    Email = "louvre@hotel.com",
                    Phone = "+33 987654321"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Big Ben Hotel",
                    StreetName = "Westminster Rd",
                    StreetNo = "5",
                    Zipcode = 10001,
                    City = "London",
                    Country = "UK",
                    Email = "bigben@hotel.com",
                    Phone = "+44 123456789"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Thames View Inn",
                    StreetName = "River St",
                    StreetNo = "18A",
                    Zipcode = 10002,
                    City = "London",
                    Country = "UK",
                    Email = "thames@hotel.com",
                    Phone = "+44 987654321"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Berlin Central Hotel",
                    StreetName = "Hauptstrasse",
                    StreetNo = "77",
                    Zipcode = 10115,
                    City = "Berlin",
                    Country = "Germany",
                    Email = "central@hotel.com",
                    Phone = "+49 123456789"
                },
                new Hotel
                {
                    ID = 6,
                    Name = "Brandenburger Inn",
                    StreetName = "Torstrasse",
                    StreetNo = "66B",
                    Zipcode = 10117,
                    City = "Berlin",
                    Country = "Germany",
                    Email = "brandenburg@hotel.com",
                    Phone = "+49 987654321"
                } );

            modelBuilder.Entity<Room>().HasData(
                new Room { ID = 1, Type = "Single", Capacity = 1, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(1), Rating = 4.2, Price = 100, },
                new Room { ID = 2, Type = "Double", Capacity = 2, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(2), Rating = 4.5, Price = 150, },
                new Room { ID = 3, Type = "Suite", Capacity = 4, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(3), Rating = 4.8, Price = 300, },
                new Room { ID = 4, Type = "Single", Capacity = 1, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(1), Rating = 3.8, Price = 90, },
                new Room { ID = 5, Type = "Double", Capacity = 2, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(2), Rating = 4.0, Price = 140, },
                new Room { ID = 6, Type = "Suite", Capacity = 4, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(3), Rating = 4.6, Price = 280, },
                new Room { ID = 7, Type = "Single", Capacity = 1, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(1), Rating = 4.0, Price = 110, },
                new Room { ID = 8, Type = "Double", Capacity = 2, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(2), Rating = 4.1, Price = 160, },
                new Room { ID = 9, Type = "Suite", Capacity = 4, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(3), Rating = 4.9, Price = 310, },
                new Room { ID = 10, Type = "Single", Capacity = 1, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(1), Rating = 3.9, Price = 95, },
                new Room { ID = 11, Type = "Double", Capacity = 2, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(2), Rating = 4.2, Price = 145, },
                new Room { ID = 12, Type = "Suite", Capacity = 4, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(3), Rating = 4.7, Price = 295, },
                new Room { ID = 13, Type = "Single", Capacity = 1, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(1), Rating = 4.3, Price = 105, },
                new Room { ID = 14, Type = "Double", Capacity = 2, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(2), Rating = 4.4, Price = 155, },
                new Room { ID = 15, Type = "Suite", Capacity = 4, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(3), Rating = 4.9, Price = 320, },
                new Room { ID = 16, Type = "Single", Capacity = 1, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(1), Rating = 4.1, Price = 98, },
                new Room { ID = 17, Type = "Double", Capacity = 2, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(2), Rating = 4.3, Price = 142, },
                new Room { ID = 18, Type = "Suite", Capacity = 4, CheckIn = DateTime.Today, CheckOut = DateTime.Today.AddDays(3), Rating = 4.6, Price = 305, }
            );
        }

    }
}
