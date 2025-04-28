using Booking_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Booking_Api.Models;

namespace Booking_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/package
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        // GET: api/package/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var package = await _context.Bookings.FindAsync(id);
            if (package == null)
            {
                return NotFound("No package with this ID");
            }
            return Ok(package);

            /*
             * BookingById needs to following:
             * - Booking itself
             * - Employee who created the package
             * - - Id and Name
             * - Enough flight data that the flight can be identified
             * - - 
             * - Enough hotelreservation data that the hotelreservation can be identified
             */
        }

        // POST: api/package
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking
            (List<Attendee> attendees)
        {
            return null;
        }

        // PUT: api/package/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBooking(int id, Booking package)
        //{
        //    if (id != package.Id)
        //    {
        //        return BadRequest("ID mismatch");
        //    }
        //    _context.Entry(package).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BookingExists(id))
        //        {
        //            return NotFound("No package with this ID");
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    return NoContent();
        //}


    }
}
