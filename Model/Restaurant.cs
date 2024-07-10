using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Cecilious.Model
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantCategory")]

        public int? RestaurantCategoryId { get; set; }

        [ForeignKey("RestaurantAddress")]

        public int RestaurantAddressId { get; set; }

       
        public string RestaurantName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Description { get; set; } = null!;

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();


        public virtual RestaurantAddress RestaurantAddress { get; set; } = null!;


        public virtual RestaurantCategory? RestaurantCategory { get; set; }


    }
}
