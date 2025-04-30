using Flight_Asp.NetCoreWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Flight_Asp.NetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FlightDbContext _context;
        public FlightController(FlightDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlightsByCriteria(
        string destinationFrom = null, string destinationTo = null, DateTime? date = null, string flightnumber = null)
        {
            var query = _context.Flights.AsQueryable();

            // Apply filters based on provided criteria
            if (!string.IsNullOrEmpty(destinationFrom))
            {
                //query = query.Where(f => f.DestinationFrom == destinationFrom);
                query = query.Where(f => f.DestinationFrom.Contains(destinationFrom));
            }

            if (!string.IsNullOrEmpty(destinationTo))
            {
                query = query.Where(f => f.DestinationTo.Contains(destinationTo));
            }

            if (date.HasValue)
            {
                // Extract the date part from TimeDeparture and compare it with the provided date
                query = query.Where(f => f.TimeDeparture.Date == date.Value.Date);
            }

            if (!string.IsNullOrEmpty(flightnumber))
            {
                query = query.Where(f => f.FlightNumber.Contains(flightnumber));
            }

            // Execute the query and get the results
            var flights = await query.ToListAsync();

            if (flights == null || !flights.Any())
            {
                return NotFound("No flights found matching the criteria.");
            }

            return Ok(flights);
        }

    }
}





