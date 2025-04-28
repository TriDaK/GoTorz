using HotelAPI.Data;
using HotelAPI.DTO;
using HotelAPI.Models;
// using Microsoft.AspNetCore.Components; // hvis denne er på er der en fejl på "Route", jeg ved ikke om den skal bruges andre steder 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly HotelDBContext _context;

        public HotelRoomController(HotelDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelRoomByCriteria(
            int? hotelID = null, int? roomID = null , string city = null ,  int? capacity = null) 
        {
            var query = _context.Rooms.Include(r => r.Hotel).AsQueryable(); //Rooms DbSet in HotelDBContext

            // search filters based on incoming criterias 
            if (hotelID.HasValue) // hotelID
            {
                query = query.Where(r => r.HotelID == hotelID);
            }
            if (roomID.HasValue) // roomID
            {
                query = query.Where(r => r.ID == roomID); // fix så den tager room.ID og ikke hotel.ID
            }
            if (!string.IsNullOrEmpty(city)) // city
            {
                query = query.Where(r => r.Hotel.City.Contains(city));
            }
            if (capacity.HasValue) // capacity
            {
                query = query.Where(r => r.Capacity == capacity);
            }

            var rooms = await query.Select(r => new RoomDTO
            {
                RoomID = r.ID,
                Type = r.Type, 
                Capacity = r.Capacity,
                CheckIn = r.CheckIn,
                CheckOut = r.CheckOut,
                Rating = r.Rating,
                Price = r.Price,
                HotelID = r.Hotel.ID,
                Name = r.Hotel.Name,
                StreetName = r.Hotel.StreetName,
                StreetNo = r.Hotel.StreetNo,
                Zipcode = r.Hotel.Zipcode,
                City = r.Hotel.City,
                Country = r.Hotel.Country,
                Email = r.Hotel.Email,
                Phone = r.Hotel.Phone
            }).ToListAsync();

            return Ok(rooms);
        }
    }
}
