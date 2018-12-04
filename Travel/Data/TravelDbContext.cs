using Microsoft.EntityFrameworkCore;
using Travel.Models.Entites.OrderModels;
using Travel.Models.Entites.OrderModels.TourModels;
using Travel.Models.Entites.UserModels;
using Travel.Models.Entites.UserModels.OperatorModels;

namespace Travel.Data
{
    public class TravelDbContext : DbContext
    {
        public TravelDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Resort> Resorts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
