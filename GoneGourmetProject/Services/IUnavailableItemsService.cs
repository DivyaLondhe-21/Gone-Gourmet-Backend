using GoneGourmetProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoneGourmetProject.Services
{
    public interface IUnavailableItemsService
    {
        Task<List<UnavailableItem>> GetUnavailableItemsAsync(string brand, List<string> locations);
        Task<List<string>> GetRestaurantBrandsAsync();
        Task<List<string>> GetLocationsByBrandAsync(string restaurantBrand);
    }
}
