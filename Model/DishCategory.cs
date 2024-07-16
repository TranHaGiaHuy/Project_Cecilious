using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Cecilious.Model
{
    public class DishCategory
    {
        [Key]
        public int DishCategoryId { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
