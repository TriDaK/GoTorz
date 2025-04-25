using HotelAPI.Data;
using HotelAPI.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")] /////// HVORFOOOOOOOOOOR?????
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly HotelDBContext _context;

        public HotelRoomController(HotelDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelRoomByCriteria() /* indsæt de kriterier man kan bruge til at søge hotel efter
                                                                                      * by, kapasitet, 
                                                                                      == null til at starte med, så de ikke søges efter hvis de ikke er sat */
        {
            var query = _context.Hotels.AsQueryable(); //Hotels DbSet in HotelDBContext

            // search filters based on incoming criterias 
            // if statements
                /* 
                 * if (!string.IsNullOrEmpty(destinationTo))
                {
                query = query.Where(f => f.DestinationTo.Contains(destinationTo));
                }
                */
            // City - alle der ligger indenfor den by 
            // capacity - værelser med minimum den kapasitet

            var hotels = await query.ToListAsync();

            return Ok(hotels);
        }
    }
}
