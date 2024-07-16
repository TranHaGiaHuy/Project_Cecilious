using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Cecilious.Model
{
    public class RestaurantCategory
    {
        [Key]

        public int RestaurantCategoryId { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
