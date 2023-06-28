using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CLOUD_POE_3.Models;

namespace CLOUD_POE_3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CLOUD_POE_3.Models.Car> Car { get; set; } = default!;
        public DbSet<CLOUD_POE_3.Models.Driver> Driver { get; set; } = default!;
        public DbSet<CLOUD_POE_3.Models.Inspector> Inspector { get; set; } = default!;
        public DbSet<CLOUD_POE_3.Models.Rental> Rental { get; set; } = default!;
        public DbSet<CLOUD_POE_3.Models.RentalReturn> RentalReturn { get; set; } = default!;
    }
}