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
    public class RoomsController : ControllerBase
    {
        private readonly HotelDBContext _context;

        public RoomsController(HotelDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelRoomByCriteria(
            int? hotelID = null, int? roomID = null , string city = null ,  int? capacity = null) 
        {
            var query = _context.Rooms.Include(r => r.Hotel).AsQueryable(); //Rooms DbSet in HotelDBContext

            // search filters based on incoming criterias 
            if (hotelID.HasValue)
            {
                query = query.Where(r => r.HotelID == hotelID);
            }
            if (roomID.HasValue)
            {
                query = query.Where(r => r.ID == roomID);
            }
            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(r => r.Hotel.City.Contains(city));
            }
            if (capacity.HasValue)
            {
                query = query.Where(r => r.Capacity >= capacity);
            }

            // query rooms with criterias and save in list 
            var rooms = await query.Select(r => new RoomDTO
            { // the data from the DB we want to send out of the API
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

            // if no rooms found with the criterias
            if(rooms == null || rooms.Any())
            {
                return NotFound("No rooms found matching the criterias");
            }

            return Ok(rooms);
        }
    }
}
