using Package_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Package_Api.Models;

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
        }

        // POST: api/package
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(Package package)
        {
            if (package == null)
            {
                return BadRequest("Package returned null");
            }

            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPackage), new { id = package.Id }, package);
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
