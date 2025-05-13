using Gotorz.Models;

namespace Gotorz.Services
{
    public class TravelPackageService
    {
        public TravelPackage CreateTravelPackage(string name, string description, Flight selectedFlight, Hotel selectedHotel)
        {
            var travelPackage = new TravelPackage
            {
                Name = name,
                Description = description,
                SelectedFlight = selectedFlight,
                SelectedHotel = selectedHotel,
                TotalPrice = selectedFlight.Price + selectedHotel.Price
            };

            return travelPackage;
        }
    }
}

