using Package_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Package_Api.Models;
using Package_Api.DTOs;

namespace Package_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PackageController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/package
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackages()
        {
            return await _context.Packages.ToListAsync();
        }

        // GET: api/package/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return NotFound("No package with this ID");
            }
            return Ok(package);

            /*
             * PackageById needs to following:
             * - Package itself
             * - Employee who created the package
             * - - Id and Name
             * - Enough flight data that the flight can be identified
             * - - 
             * - Enough hotelreservation data that the hotelreservation can be identified
             */
        }

        // POST: api/package
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage
            ([FromBody] PackageCreateRequest request)
        {
            // Request body
            var flights = request.Flights;
            var rooms = request.Rooms;
            var employeeId = request.EmployeeId;
            var name = request.Name;
            var description = request.Description;


            // Init employee
            Employee employee = null;
            
            // Check if incoming data is valid
            if (flights == null)
                return BadRequest("Flights are null");
            if (rooms == null)
                return BadRequest("Rooms are null");
            if (employeeId <= 0)
                return BadRequest("Employee ID is negative");
            if (string.IsNullOrEmpty(name))
                return BadRequest("Name is empty or null");
            if (string.IsNullOrEmpty(description))
                return BadRequest("Description is empty or null");
            // Check if employee exists
            try
            {
                employee = await _context.Employees.FindAsync(employeeId);
                if (employee == null)
                    return NotFound("Employee not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error finding employee: {ex.Message}");
            }

            // Set package with incoming information
            Package newPackage = new Package
            {
                EmployeeId = employeeId,
                Employee = employee,
                Flights = flights,
                AvailableRooms = rooms,
                Name = name,
                Description = description,
            };

            // Assign foreign keys to flights and rooms
            foreach (var flight in flights)
            {
                flight.PackageId = newPackage.Id; // Set PackageId for each flight
            }

            foreach (var room in rooms)
            {
                room.PackageId = newPackage.Id;  // Set PackageId for each room or room reservation
            }

            /*
             * Following are the temporary data to fill out a package with dummy
             * Current dummy includes: 
             * Pictures
             */
            List<Picture> pictures = new List<Picture>();
            newPackage.Pictures = pictures;

            // Package to context
            _context.Packages.Add(newPackage);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPackage), new { id = newPackage.Id }, newPackage);
        }

        // PUT: api/package/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPackage(int id, Package package)
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
        //        if (!PackageExists(id))
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
