using Microsoft.EntityFrameworkCore;
using Travel.Models.Entites;

namespace Travel.Data
{
    public class TravelDbContext : DbContext
    {
        public TravelDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
