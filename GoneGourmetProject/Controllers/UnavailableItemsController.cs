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

        public UnavailableItemsController(IUnavailableItemsService service)
        {
            _service = service;
        }

        [HttpPost("get-unavailable-items")]
        public async Task<IActionResult> GetUnavailableItems([FromBody] UnavailableItemsRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.RestaurantBrand) || request.Locations == null)
                return BadRequest("Invalid request");

            try
            {
                var result = await _service.GetUnavailableItemsAsync(request.RestaurantBrand, request.Locations);
                return Ok(new { UnavailableItems = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<string>>> GetRestaurantBrands()
        {
            var brands = await _service.GetRestaurantBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("locations")]
        public async Task<ActionResult<List<string>>> GetLocations([FromQuery] string restaurantBrand)
        {
            var locations = await _service.GetLocationsByBrandAsync(restaurantBrand);
            return Ok(locations);
        }
    }
}
