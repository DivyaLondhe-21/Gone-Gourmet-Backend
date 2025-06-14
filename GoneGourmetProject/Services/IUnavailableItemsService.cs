using GoneGourmetProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoneGourmetProject.Services
{
    public interface IUnavailableItemsService
    {
        Task<List<UnavailableItem>> GetUnavailableItemsAsync(string restaurantBrand, string location);
        Task<List<string>> GetRestaurantBrandsAsync();
        Task<List<string>> GetLocationsByBrandAsync(string restaurantBrand);
    }
}
