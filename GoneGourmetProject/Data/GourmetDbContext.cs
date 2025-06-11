using GoneGourmetProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GoneGourmetProject.Data
{
    public class GourmetDbContext : DbContext
    {
        public GourmetDbContext(DbContextOptions<GourmetDbContext> options) : base(options)
        {
        }
        public DbSet<RestaurantBrand> RestaurantBrands { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UnavailableItem> UnavailableItems { get; set; }
    }
}
