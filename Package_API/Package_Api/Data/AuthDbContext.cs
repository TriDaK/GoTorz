using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Package_Api.Models.Login;

namespace Package_Api.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<User> User { get; set; }
}
}
