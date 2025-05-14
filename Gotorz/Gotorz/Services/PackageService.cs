using Gotorz.Models;

namespace Gotorz.Services
{
    public class PackageService
    {
        private readonly HttpClient _httpClient; // the HttpClient used in this service
        public PackageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Package>> SearchPackagesAsync(string from, string to, DateTime departureDate)
        {
            string url = $"https://localhost:5003/api/Package?from={from}&to={to}&date={departureDate:yyyy-MM-dd}";
            return await _httpClient.GetFromJsonAsync<List<Package>>(url) ?? new List<Package>();
        }
        public async Task<Package?> SearchPackageAsyncByID(int id) // ? because then it is OK to search a package that dosn't exist 
        {
            string url = $"https://localhost:5003/api/Package/{id}";
            return await _httpClient.GetFromJsonAsync<Package>(url);
        }
        public async Task<List<Package>> GetAllPackages()
        {
            string url = $"https://localhost:5003/api/Package";
            return await _httpClient.GetFromJsonAsync<List<Package>>(url) ?? new List<Package>();
        }
    }
}