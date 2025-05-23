using Gotorz.Models;

namespace Gotorz.Services
{
    public interface IFlightService
    {
        Task<List<Flight>> SearchFlightsAsync(string? from, string? to, DateTime? departureDate, string? flightNumber);
    }
}