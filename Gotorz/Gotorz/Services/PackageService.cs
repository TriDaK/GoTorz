using Gotorz.Models;
using Gotorz.Models.PackageDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Gotorz.Services
{
    public class PackageService : IPackageService
    {
        private readonly HttpClient _httpClient; // the HttpClient used in this service

        public PackageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreatePackageAsync(PackageApiPackage package)
        {
            Console.WriteLine($"Request Data: {System.Text.Json.JsonSerializer.Serialize(package)}");

            var response = await _httpClient.PostAsJsonAsync("api/Package", package);
            return response;
        }
        public PackageApiPackage CreatePackage(string name, string description, List<Flight> selectedFlights, List<Hotel> selectedHotels)
        {
            var package = new PackageApiPackage
            {
                Name = name,
                Description = description,
                Flights = selectedFlights.Select(f => new PackageApiFlight
                {
                    FlightNumber = f.FlightNumber,
                    TimeDeparture = f.TimeDeparture
                }).ToList(),

                Rooms = selectedHotels.Select(h => new PackageApiRoom
                {
                    RoomCapacity = h.Capacity,
                    RoomType = h.Type,
                    CheckIn = h.CheckIn,
                    CheckOut = h.CheckOut
                }).ToList(),

                Hotel = new PackageApiHotel
                {
                    Phone = selectedHotels[0].Phone
                },

                Employee = new Employee 
                { 
                    EmployeeId = 1 // forced employeeID = 1 until autentication 
                } 
            };

            return package;
        }

        public async Task<List<Package>> SearchPackagesAsync(string? city, string? country, DateTime? date)
        {
            string url = "https://localhost:5003/api/Package/search?";

            if (!string.IsNullOrWhiteSpace(city))
            {
                url += $"city={city}&";
            }
            if (!string.IsNullOrWhiteSpace(country))
            {
                url += $"country={country}&";
            }
            if (date != DateTime.Today)
            {
                url += $"date={date:yyyy-MM-dd}";
            }

            List<Package> packages = new();
            var apiPackages = await _httpClient.GetFromJsonAsync<List<PackageApiPackage>>(url) ?? new List<PackageApiPackage>();

            foreach (var package in apiPackages)
            {
                packages.Add(
                    new Package
                    {
                        Id = package.Id,
                        Name = package.Name,
                        Description = package.Description,
                        Employee = package.Employee,
                        Flights = package.Flights.Select(f => new Flight
                        {
                            FlightNumber = f.FlightNumber,
                            TimeDeparture = f.TimeDeparture
                        }).ToList()
                        ////////////////////////// ADD hotel and room info. Alt det vi får fra API'en. Evt. udvide API'en 
                    });
            }
            return packages;
        }

        public async Task<Package?> SearchPackageAsyncByID(int id) // ? because then it is OK to search a package that dosn't exist 
        {
            string url = $"https://localhost:5003/api/Package/{id}";
            var apiPackage = await _httpClient.GetFromJsonAsync<PackageApiPackage>(url) ?? new PackageApiPackage();

            var package = new Package
            {
                Id = apiPackage.Id,
                Name = apiPackage.Name,
                Description = apiPackage.Description,
                Employee = apiPackage.Employee,
                Flights = apiPackage.Flights.Select(f => new Flight
                {
                    FlightNumber = f.FlightNumber,
                    TimeDeparture = f.TimeDeparture
                }).ToList()
            };
            return package;
        }

        public async Task<List<Package>> GetAllPackagesAsync()
        {
            string url = $"https://localhost:5003/api/Package";
            List<Package> packages = new();
            var apiPackages = await _httpClient.GetFromJsonAsync<List<PackageApiPackage>>(url) ?? new List<PackageApiPackage>();

            foreach (var package in apiPackages)
            {
                packages.Add(
                    new Package
                    {
                        Id = package.Id,
                        Name = package.Name,
                        Description = package.Description,
                        Employee = package.Employee,
                        Flights = package.Flights.Select(f => new Flight
                        {
                            FlightNumber = f.FlightNumber,
                            TimeDeparture = f.TimeDeparture
                        }).ToList()
                    });
            }
            return packages;
        }
    }
}
