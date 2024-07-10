using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Cecilious.Model
{
    public class RestaurantAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RestaurantAddressId { get; set; }

        public string HouseNumber { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string District { get; set; } = null!;

        public string Province { get; set; } = null!;

        public string GoogleMapLink { get; set; } = null!;

        public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
