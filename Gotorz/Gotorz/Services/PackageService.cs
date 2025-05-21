using Gotorz.Models;
using Gotorz.Models.PackageDTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class PackageService
{
    private readonly HttpClient _httpClient;

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
            EmployeeId = 1
        };

        return package;
    }
}
