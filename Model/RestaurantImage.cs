using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Cecilious.Model
{
	public class RestaurantImage
	{
		[Key]
		public int ResImageID { get; set; }

		[ForeignKey("Restaurant")]

		public int RestaurantId { get; set; }

		public string ImagePath { get; set; } = null!;
	}
}
