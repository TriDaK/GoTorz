namespace Gotorz.Models
{
    public class TravelPackage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Flight? SelectedFlight { get; set; }
        public Hotel? SelectedHotel { get; set; }
        public double TotalPrice { get; set; }
    }

}
