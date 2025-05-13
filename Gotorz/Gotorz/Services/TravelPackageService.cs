using Gotorz.Models;

namespace Gotorz.Services
{
    public class TravelPackageService
    {
        public TravelPackage CreateTravelPackage(Flight selectedFlight, Hotel selectedHotel)
        {
            var travelPackage = new TravelPackage
            {
                SelectedFlight = selectedFlight,
                SelectedHotel = selectedHotel,
                TotalPrice = selectedFlight.Price + selectedHotel.Price
            };

            return travelPackage;
        }
    }
}
