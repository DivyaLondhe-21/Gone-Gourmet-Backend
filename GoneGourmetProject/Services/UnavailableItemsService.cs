using GoneGourmetProject.Data;
using GoneGourmetProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GoneGourmetProject.Services
{
    public class UnavailableItemsService : IUnavailableItemsService
    {
        private readonly GourmetDbContext _context;

        public UnavailableItemsService(GourmetDbContext context)
        {
            _context = context;
        }

        public async Task<List<UnavailableItem>> GetUnavailableItemsAsync(string brand, List<string> locations)
        {
            return await _context.UnavailableItems
                .Where(ui => locations.Contains(ui.Location.City) &&
                             ui.Location.Brand.BrandName.ToLower() == brand.ToLower())
                .ToListAsync();
        }

        public async Task<List<string>> GetRestaurantBrandsAsync()
        {
            return await _context.RestaurantBrands
                .Select(rb => rb.BrandName)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<string>> GetLocationsByBrandAsync(string restaurantBrand)
        {
            return await _context.Locations
                .Where(l => l.Brand.BrandName == restaurantBrand)
                .Select(l => l.City)
                .Distinct()
                .ToListAsync();
        }
    }
}
