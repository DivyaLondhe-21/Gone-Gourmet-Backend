using GoneGourmetProject.Data;
using GoneGourmetProject.Models;
using GoneGourmetProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoneGourmetProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnavailableItemsController : ControllerBase
    {
        private readonly IUnavailableItemsService _service;
        private readonly GourmetDbContext _context;

        public UnavailableItemsController(IUnavailableItemsService service, GourmetDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost("get-unavailable-items")]
        public async Task<ActionResult<List<UnavailableItem>>> GetUnavailableItems
            ([FromQuery] string restaurantBrand, [FromQuery] string location)
        {
            var result = await _service.GetUnavailableItemsAsync(restaurantBrand, location);
            return Ok(result);
        }

        [HttpGet("brands")]
        public IActionResult GetBrands()
        {
            var brands = _context.UnavailableItems 
                .Select(ui => ui.RestaurantBrand)
                .Distinct()
                .Where(brand => !string.IsNullOrEmpty(brand))
                .Select((name, idx) => new { id = idx + 1, name })
                .ToList();

            return Ok(brands);
        }

        [HttpGet("cities")]
        public IActionResult GetCities([FromQuery] string brandName)
        {
            var cities = _context.UnavailableItems
                .Where(ui => ui.RestaurantBrand == brandName)
                .Select(ui => ui.Location)
                .Distinct()
                .Where(city => !string.IsNullOrEmpty(city))
                .Select((name, idx) => new { id = idx + 1, name })
                .ToList();

            return Ok(cities);
        }

        [HttpGet("unavailable-items")]
        public IActionResult GetUnavailableItemsForBrandAndCity([FromQuery] string brandName, [FromQuery] string cityName)
        {
            var items = _context.UnavailableItems
                .Where(ui => ui.RestaurantBrand == brandName && ui.Location == cityName)
                .Select(ui => new { name = ui.ItemName, ui.Reason })
                .ToList();
            return Ok(items);
        }
    }
}
