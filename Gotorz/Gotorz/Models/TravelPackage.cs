namespace Gotorz.Models
{
    public class TravelPackage
    {
        public int ID { get; set; }
        public Flight SelectedFlight { get; set; }
        public Hotel SelectedHotel { get; set; }
        public double TotalPrice { get; set; }
    }
}
