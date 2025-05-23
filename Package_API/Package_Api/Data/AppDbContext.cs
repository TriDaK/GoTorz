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

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Package)
                .WithMany(p => p.Flights)
                .HasForeignKey(f => f.PackageId);

            modelBuilder.Entity<AvailableRoom>()
                .HasOne(hr => hr.Package)
                .WithMany(p => p.AvailableRooms)
                .HasForeignKey(hr => hr.PackageId);

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Batman"}
                );
        }
    }
}
