using Gotorz.Models;
using Gotorz.Models.PackageDTOs;

namespace Gotorz.Services
{
    public class PackageService : IPackageService
    {
        private readonly HttpClient _httpClient; // the HttpClient used in this service

        public PackageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
                    });
            }
            return packages;
        }

        public async Task<Package?> SearchPackageAsyncByID(int id) // ? because then it is OK to search a package that dosn't exist 
        {
            string url = $"https://localhost:5003/api/Package/{id}";
            return await _httpClient.GetFromJsonAsync<Package>(url);
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