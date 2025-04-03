using Microsoft.EntityFrameworkCore;
using Package_Api.Models;

namespace Package_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Attendee is a value object or separate entity
            modelBuilder.Entity<Booking>()
                .OwnsMany(b => b.Attendees);

            modelBuilder.Entity<Package>()
                .HasOne(p => p.Employee)
                .WithMany() // No navigation from Employee to Package
                .HasForeignKey(p => p.EmployeeId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Package)
                .WithMany() // no nav from Package to Bookings
                .HasForeignKey(b => b.PackageId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Payment)
                .WithOne()
                .HasForeignKey<Booking>(b => b.PaymentId);

            modelBuilder.Entity<Payment>()
                .Property(p => p.PaymentMethod)
                .IsRequired(false); // Just a reminder this is nullable
        }
    }
}
