using Microsoft.EntityFrameworkCore;
using Package_Api.Models;

namespace Package_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<AvailableRoom> AvailableRooms { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvailableRoom>()
                .HasOne(r => r.Hotel)
                .WithMany(h => h.AvailableRooms)
                .HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Package>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Packages)
                .HasForeignKey(p => p.EmployeeId);

            modelBuilder.Entity<Picture>()
                .HasOne(pic => pic.Package)
                .WithMany(p => p.Pictures)
                .HasForeignKey(pic => pic.PackageId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithOne(b => b.Payment)
                .HasForeignKey<Payment>(p => p.BookingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendee>()
                .HasOne(a => a.Booking)
                .WithMany(b => b.Attendees)
                .HasForeignKey(a => a.BookingId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade manually, no conflict

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentStatus)
                .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentDue)
                .HasConversion(
                    d => d.ToDateTime(TimeOnly.MinValue),
                    d => DateOnly.FromDateTime(d)
                );

            modelBuilder.Entity<Booking>()
                .Property(b => b.BookingDate)
                .HasConversion(
                    d => d.ToDateTime(TimeOnly.MinValue),
                    d => DateOnly.FromDateTime(d)
                );

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Package)
                .WithMany(p => p.Flights)
                .HasForeignKey(f => f.PackageId);

            modelBuilder.Entity<AvailableRoom>()
                .HasOne(hr => hr.Package)
                .WithMany(p => p.AvailableRooms)
                .HasForeignKey(hr => hr.PackageId);

            modelBuilder.Entity<Payment>()
                .Property(p => p.FinalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Package>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<AvailableRoom>()
                .Property(hr => hr.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
