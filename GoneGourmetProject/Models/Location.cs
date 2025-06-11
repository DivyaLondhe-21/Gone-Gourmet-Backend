using System.ComponentModel.DataAnnotations;

namespace GoneGourmetProject.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; } //primary key
        public string City { get; set; }
        public int BrandId { get; set; } //foreign key
        public RestaurantBrand Brand { get; set; }
        public ICollection<UnavailableItem> UnavailableItems { get; set; }


    }
}
