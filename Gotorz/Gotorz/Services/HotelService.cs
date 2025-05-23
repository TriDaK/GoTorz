using Gotorz.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class HotelService
{
    private readonly HttpClient _httpClient; // the HttpClient used in this service

    public HotelService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Hotel>> SearchHotelsAsync(
        string? city,
        DateTime? checkInDate,
        DateTime? checkOutDate,
        double? rating,
        int? capacity,
        string? roomType)
    {
        string url = "https://localhost:5002/api/Rooms?";

        if (!string.IsNullOrWhiteSpace(city))
        {
            url += $"city={city}&";
        }
        if (checkInDate.HasValue)
        {
            url += $"checkIn={checkInDate:yyyy-MM-dd}&";
        }
        if (checkOutDate.HasValue)
        {
            url += $"checkOut={checkOutDate:yyyy-MM-dd}&";
        }
        if (rating.HasValue)
        {
            url += $"rating={rating}&";
        }
        if (capacity.HasValue)
        {
            url += $"capacity={capacity}&";
        }
        if (!string.IsNullOrWhiteSpace(roomType))
        {
            url += $"roomType={roomType}&";
        }

        // Remove the trailing '&' or '?' if present
        if (url.EndsWith("&") || url.EndsWith("?"))
        {
            url = url[..^1];
        }

        try
        {
            Console.WriteLine($"Making request to: {url}");

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response: {responseBody}");

            var hotels = await _httpClient.GetFromJsonAsync<List<Hotel>>(url) ?? new List<Hotel>();
            Console.WriteLine($"Found {hotels.Count} hotels.");

            return hotels;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<Hotel>(); // Return a blank list in case of an error
        }
    }
}