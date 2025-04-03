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
        public async Task<ActionResult<List<Flight>>> GetFlights()
        {
            return Ok(await _context.Flights.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlightById(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight is null)
            {
                return NotFound();
            }
            return Ok(flight);
        }


        [HttpPost]
        public async Task<ActionResult<Flight>> AddFlight(Flight newFlight)
        {
            if (newFlight is null)
                return BadRequest();

            _context.Flights.Add(newFlight);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFlightById), new { id = newFlight.Id }, newFlight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, Flight updatedFlight)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight is null)
            {
                return NotFound();
            }

            // opdaterer flyinformation pånær id
            flight.FlightNumber = updatedFlight.FlightNumber;
            flight.FlightStatus = updatedFlight.FlightStatus;
            flight.DestinationFrom = updatedFlight.DestinationFrom;
            flight.DestinationTo = updatedFlight.DestinationTo;
            flight.TimeDeparture = updatedFlight.TimeDeparture;
            flight.TimeArrival = updatedFlight.TimeArrival;

            await _context.SaveChangesAsync();

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task <ActionResult> DeleteFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight is null)
            {
                return NotFound();
            }
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}





