using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Gotorz.Models;


namespace Gotorz.Services
{
    public class FlightService
    {
        private readonly HttpClient _httpClient; // the HttpClient used in this service

        public FlightService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Flight>> SearchFlightsAsync (string from, string to, DateTime departureDate)
        {
            string url = $"https://localhost:5001/api/Flights?from={from}&to={to}&date={departureDate:yyyy-MM-dd}";

            return await _httpClient.GetFromJsonAsync<List<Flight>>(url) ?? new List<Flight>();
        }

        public async Task<Flight?> SearchFlightAsyncByID(int id) // ? because then it is OK to search a fligth that dosn't exist 
        {
            string url = $"https://localhost:5001/api/Flights/{id}";
            return await _httpClient.GetFromJsonAsync<Flight>(url);
        }
    }
}
