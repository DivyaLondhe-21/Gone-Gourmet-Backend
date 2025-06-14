using System.ComponentModel.DataAnnotations;

namespace GoneGourmetProject.Models
{
    public class UnavailableItem
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Reason { get; set; }

        public string RestaurantBrand { get; set; } 
        public string Location { get; set; }

    }
}
