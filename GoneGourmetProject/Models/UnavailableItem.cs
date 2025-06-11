using System.ComponentModel.DataAnnotations;

namespace GoneGourmetProject.Models
{
    public class UnavailableItem
    {
        [Key]
        public int ItemId { get; set; } //primary key
        public string ItemName { get; set; }
        public string Reason { get; set; }

        public int LocationId { get; set; } //foreign key
        public Location Location { get; set; }

    }
}
