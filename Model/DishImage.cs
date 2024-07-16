using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Cecilious.Model
{
	public class DishImage
	{
		[Key]
		public int DishImageID { get; set; }
		
		[ForeignKey("Dish")]
		public int DishId { get; set; }
		public string ImagePath { get; set; } = null!;
	}
}
