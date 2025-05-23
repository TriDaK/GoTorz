using Package_Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Package_Api.Models;
using Package_Api.DTOs;
using Microsoft.Data.SqlClient;
using Package_Api.Utility;

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
        public async Task<ActionResult<IEnumerable<PackageResponseDto>>> GetPackages()
        {
            try
            {
                var packages = await _context.Packages
                    .Include(p => p.Employee)
                    .Include(p => p.Flights)
                    .ToListAsync();

                var response = new List<PackageResponseDto>();

                foreach (var package in packages)
                {
                    response.Add(
                        new PackageResponseDto
                        {
                            Id = package.Id,
                            Name = package.Name,
                            Description = package.Description,
                            Employee = new EmployeeDto
                            {
                                EmployeeId = package.Employee.Id,
                                EmployeeName = package.Employee.Name
                            },
                            Flights = package.Flights.Select(f => new FlightDto
                            {
                                Departure = f.Departure,
                            }).ToList()
                        });
                }

                return Ok(response);
            }

            catch (Exception ex)
            {
                // Logging should be here as well
                return ResponseHelper.HandleDatabaseError(ex);
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PackageResponseDto>>> GetPackagesByCriteria(
            string city = null, string country = null, DateTime? date = null) 
        {
            try
            {
                var basesQuery = _context.Packages.Include(p => p.Employee)
                                                .Include(p => p.Flights)
                                                .Include(p => p.AvailableRooms)
                                                    .ThenInclude(r => r.Hotel);
                IQueryable<Package> query = basesQuery;

                // search filters based on incoming criterias 
                if (!string.IsNullOrEmpty(city))
                {
                    query = query.Where(p => p.AvailableRooms.Any(r => r.Hotel.City.Contains(city)));
                }
                if (!string.IsNullOrEmpty(country))
                {
                    query = query.Where(p => p.AvailableRooms.Any(r => r.Hotel.Country.Contains(country)));
                }
                if (date.HasValue)
                {
                    var dateOnly = date.Value.Date;
                    query = query.Where(p =>
                        p.Flights.Any(f => f.Departure.Date == dateOnly));
                }

                var packages = await query.ToListAsync();

                var respons = packages.Select(package => new PackageResponseDto
                {
                    Id = package.Id,
                    Name = package.Name,
                    Description = package.Description,
                    Employee = new EmployeeDto
                    {
                        EmployeeId = package.Employee.Id,
                        EmployeeName = package.Employee.Name
                    },
                    Flights = package.Flights.Select(f => new FlightDto
                    {
                        Departure = f.Departure,
                    }).ToList(),
                    Hotel = package.AvailableRooms.GroupBy(r => r.Hotel).Select(group => new HotelWithRoomsDto
                    {
                        City = group.Key?.City,
                        Country = group.Key?.Country,
                        Rooms = group.Select(r => new RoomDto
                        {
                            RoomCapacity = r.RoomCapacity,
                            RoomType = r.RoomType,
                        }).ToList()
                    }).FirstOrDefault()
                }).ToList();

                return Ok(respons);
            }
            catch // if there is no package on the searchcriterias
            {
                return ResponseHelper.HandleNoResult();
            }
        }

        // GET: api/package/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageResponseDto>> GetPackage(int id)
        {
            try
            {
                var package = await _context.Packages
                    .Include(p => p.Flights)
                    .Include(p => p.AvailableRooms)
                        .ThenInclude(r => r.Hotel)
                    .Include(p => p.Pictures)
                    .Include(p => p.Employee)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (package == null)
                    return NotFound("Package not found");

                // Sort rooms into their hotel
                var hotelRooms = package.AvailableRooms
                    .GroupBy(r => r.Hotel)
                    .First();

                var response = new PackageResponseDto
                {
                    Id = package.Id,
                    Name = package.Name,
                    Description = package.Description,
                    Employee = new EmployeeDto
                    {
                        EmployeeId = package.Employee.Id,
                        EmployeeName = package.Employee.Name
                    },
                    Flights = package.Flights.Select(f => new FlightDto
                    {
                        FlightNumber = f.FlightNumber,
                        Departure = f.Departure
                    }).ToList(),
                    Hotel = new HotelWithRoomsDto
                    {
                        Phone = hotelRooms.Key?.Phone,
                        Rooms = hotelRooms.Select(r => new RoomDto
                        {
                            RoomCapacity = r.RoomCapacity,
                            RoomType = r.RoomType,
                            CheckIn = r.CheckIn,
                            CheckOut = r.CheckOut
                        }).ToList()
                    },
                    //Pictures = package.Pictures?.Select(pic => new PictureDto
                    //{
                    //    Id = pic.Id,
                    //    ImageBytes = pic.ImageBytes
                    //}).ToList()
                    Pictures = new List<PictureDto>()
                };

                return Ok(response);
            }

            catch (Exception ex)
            {
                // Logging should be here as well
                return ResponseHelper.HandleDatabaseError(ex);
            }
        }

        // POST: api/package
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage
            ([FromBody] PackageCreateRequest request)
        {
            try
            {
            // Request body
            var flights = request.Flights;
            var rooms = request.Rooms;
            var employeeId = request.Employee.EmployeeId;
            var name = request.Name;
            var description = request.Description;
            
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

                // Check if Hotel exists
                var existingHotel = new Hotel();
                try
                {
                    existingHotel = await _context.Hotels.FirstOrDefaultAsync
                        (h => h.Phone == request.Hotel.Phone);
                }
                catch
                {

                }

            if (existingHotel == null)
            {
                existingHotel = new Hotel 
                { 
                    Phone = request.Hotel.Phone,
                    City = request.Hotel.City,
                    Country = request.Hotel.Country
                };
                _context.Hotels.Add(existingHotel);
                await _context.SaveChangesAsync();
            }

            // Set package with incoming information
            var package = new Package
            {
                EmployeeId = request.Employee.EmployeeId,
                Name = request.Name,
                Description = request.Description,
                Flights = request.Flights.Select(f => new Flight
                {
                    FlightNumber = f.FlightNumber,
                    Departure = f.Departure
                }).ToList(),
                AvailableRooms = request.Rooms.Select(r => new AvailableRoom
                {
                    RoomCapacity = r.RoomCapacity,
                    RoomType = r.RoomType,
                    CheckIn = r.CheckIn,
                    CheckOut = r.CheckOut,
                    HotelId = existingHotel.Id
                }).ToList()
            };

            List<Picture> pictures = new List<Picture>();
            package.Pictures = pictures;

            // Package to context
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPackage), new { id = package.Id }, new
            {
                Message = "Package created successfully",
                package.Id
            });
            }

            catch (Exception ex)
            {
                // Logging should be here as well
                return ResponseHelper.HandleDatabaseError(ex);
            }
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
