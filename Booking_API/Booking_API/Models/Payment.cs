using System.ComponentModel.DataAnnotations.Schema;

namespace Booking_Api.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public decimal FinalPrice { get; set; }
        public DateOnly PaymentDue { get; set; }
        public string? PaymentMethod { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        [InverseProperty("Payment")]
        public Booking Booking { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed
    }
}
