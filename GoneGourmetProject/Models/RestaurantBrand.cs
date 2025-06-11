using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoneGourmetProject.Models
{
    public class RestaurantBrand
    {
        [Key]
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
