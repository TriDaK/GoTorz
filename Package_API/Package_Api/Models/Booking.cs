namespace Package_Api.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateOnly BookingDate { get; set; }

        public Customer Customer { get; set; }
        public Package Package { get; set; }
        public List<Attendee> Attendees { get; set; }
        public Payment Payment { get; set; }

        // Foreign keys for loading classes
        public int CustomerId { get; set; }
        public int PackageId { get; set; }
        public int PaymentId { get; set; }
    }
}
