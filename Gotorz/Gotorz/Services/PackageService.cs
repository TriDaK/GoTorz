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

    public PackageApiPackage CreatePackage(string name, string description, List<Flight> selectedFlight, List<Hotel> selectedHotel)
    { // new package dto
        var package = new PackageApiPackage //Api package istedetfor 
        {

            Name = name,
            Description = description,
            Flights = selectedFlight.Select(f => new PackageApiFlight
            {
                FlightNumber = f.FlightNumber,
                TimeDeparture = f.TimeDeparture
            }).ToList(),

            //Price = selectedFlight.Price + (decimal)selectedHotel.Price * 1.15m // ret decimal

            Rooms = selectedHotel.Select(f => new PackageApiRoom
            {
                RoomCapacity = f.Capacity,
                RoomType = f.Type,
                CheckIn = f.CheckIn,
                CheckOut = f.CheckOut
            }).ToList(),

            Hotel = new PackageApiHotel
            { Phone = selectedHotel[0].Phone },
            EmployeeId = 1
        };

        return package;
    }
}
