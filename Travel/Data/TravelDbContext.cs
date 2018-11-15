using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Travel.Models.Entites;

namespace Travel.Data
{
    public class TravelDbContext : IdentityDbContext<User>
    {
        public TravelDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
    }
}
