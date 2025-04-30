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
        string url = "https://localhost:5001/api/Hotel?";

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
            return await _httpClient.GetFromJsonAsync<List<Hotel>>(url) ?? new List<Hotel>();
        }
        catch
        {
            return new List<Hotel>(); // Return a blank list in case of an error
        }
    }
}
