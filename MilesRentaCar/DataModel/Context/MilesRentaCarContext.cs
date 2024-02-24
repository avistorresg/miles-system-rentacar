using Microsoft.EntityFrameworkCore;
using MilesRentaCar.DataModel.Models;

namespace MilesRentaCar.DataModel.Context
{
    public class MilesRentaCarContext : DbContext
    {
        public DbSet<Vehicle>? Vehicles { get; set; }
        public DbSet<Location>? Locations { get; set; }
        public DbSet<Market>? Markets { get; set; }
        public DbSet<Client>? Clients { get; set; }

        public readonly IConfiguration _configuration;

        public MilesRentaCarContext(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MilesRentaCarConnection"));
        }
    }
}
