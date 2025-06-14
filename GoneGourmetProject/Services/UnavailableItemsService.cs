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

        public async Task<List<UnavailableItem>> GetUnavailableItemsAsync(string restaurantBrand, string location)
        {
            return await _context.UnavailableItems
                .Where(ui => ui.RestaurantBrand == restaurantBrand && ui.Location == location)
                .ToListAsync();
        }

        public async Task<List<string>> GetRestaurantBrandsAsync()
        {
            return await _context.UnavailableItems
                .Select(ui => ui.RestaurantBrand)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<string>> GetLocationsByBrandAsync(string restaurantBrand)
        {
            return await _context.UnavailableItems
                .Where(l => l.RestaurantBrand == restaurantBrand)
                .Select(l => l.Location)
                .Distinct()
                .ToListAsync();
        }
    }
}
