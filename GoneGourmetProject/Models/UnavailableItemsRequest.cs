namespace GoneGourmetProject.Models
{
    public class UnavailableItemsRequest
    {
        public string RestaurantBrand { get; set; }
        public List<string> Locations { get; set; }

    }
}
