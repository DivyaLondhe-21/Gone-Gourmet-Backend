using GoneGourmetProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GoneGourmetProject.Data
{
    public class GourmetDbContext : DbContext
    {
        public GourmetDbContext(DbContextOptions<GourmetDbContext> options) : base(options)
        {
        }

        public DbSet<UnavailableItem> UnavailableItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnavailableItem>(entity =>
            {
                entity.HasKey(e => e.Id); // Set primary key  
                entity.Property(e => e.ItemName).IsRequired();
                entity.Property(e => e.Reason).IsRequired();
                entity.Property(e => e.Location).IsRequired().HasMaxLength(100);
                entity.Property(e => e.RestaurantBrand).IsRequired().HasMaxLength(100);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
