using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Gotorz.Models;


namespace Gotorz.Services
{
    public class FlightService : IFlightService
    {
        private readonly HttpClient _httpClient; // the HttpClient used in this service

        public FlightService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("FlightAPI");
        }

        public async Task<List<Flight>> SearchFlightsAsync(string? from, string? to, DateTime? departureDate, string? flightNumber)
        {
            string url = "api/Flight?";

            if (!string.IsNullOrWhiteSpace(from))
            {
                url += $"destinationFrom={from}&";
            }
            if (!string.IsNullOrWhiteSpace(to))
            {
                url += $"destinationTo={to}&";
            }
            if (!string.IsNullOrWhiteSpace(flightNumber))
            {
                url += $"flightnumber={flightNumber}&";
            }
            if (departureDate.HasValue)
            {
                url += $"date={departureDate:yyyy-MM-dd}";
            }

            try
            {
                return await _httpClient.GetFromJsonAsync<List<Flight>>(url) ?? new List<Flight>();
            }
            catch // if no respons
            {
                return new List<Flight>();
            }
        }
    }
}
