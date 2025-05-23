using Gotorz.Models;

namespace Gotorz.Services
{
    public interface IPackageService
    {
        Task<List<Package>> SearchPackagesAsync(string? city, string? country, DateTime? date);
        Task<Package?> SearchPackageAsyncByID(int id);
        Task<List<Package>> GetAllPackagesAsync();
    }
}
