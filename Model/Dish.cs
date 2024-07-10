using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Cecilious.Model
{
    public class Dish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int DishId { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        [ForeignKey("DishCategory")]
        public int DishCategoryId { get; set; }

        public string DishName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Price { get; set; }

        public string LinkToShoppe { get; set; } = null!;

        public string Image { get; set; } = null!;


        public virtual DishCategory DishCategory { get; set; } = null!;

        public virtual Restaurant Restaurant { get; set; } = null!;
    }
}
