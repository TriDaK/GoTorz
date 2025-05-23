using Gotorz.Models;

public interface IHotelService
{
    Task<List<Hotel>> SearchHotelsAsync(
        string? city,
        DateTime? checkInDate,
        DateTime? checkOutDate,
        double? rating,
        int? capacity,
        string? roomType);
}