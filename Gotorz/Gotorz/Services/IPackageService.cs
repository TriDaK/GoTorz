using Gotorz.Models;
using Gotorz.Models.PackageDTOs;

namespace Gotorz.Services
{
    public interface IPackageService
    {
        Task<HttpResponseMessage> CreatePackageAsync(PackageApiPackage package);
        PackageApiPackage CreatePackage(string name, string description, List<Flight> selectedFlights, List<Hotel> selectedHotels);
        Task<List<Package>> SearchPackagesAsync(string? city, string? country, DateTime? date);
        Task<Package?> SearchPackageAsyncByID(int id);
        Task<List<Package>> GetAllPackagesAsync();
    }
}
